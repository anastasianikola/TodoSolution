namespace Todo.Core.Tests
{
    public class TodoListTests
    {
        [Fact]
        public void Add_IncreasesCount()
        {
            var list = new TodoList();
            list.Add(" task ");
            Assert.Equal(1, list.Count);
            Assert.Equal("task", list.Items.First().Title);
        }

        [Fact]
        public void Remove_ById_Works()
        {
            var list = new TodoList();
            var item = list.Add("a");
            Assert.True(list.Remove(item.Id));
            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void Find_ReturnsMatches()
        {
            var list = new TodoList();
            list.Add("Buy milk");
            list.Add("Read book");
            var found = list.Find("buy").ToList();
            Assert.Single(found);
            Assert.Equal("Buy milk", found[0].Title);
        }

        [Fact]
        public void SaveAndLoad_WorksCorrectly()
        {
            // Arrange
            var originalList = new TodoList();
            originalList.Add("Task 1");
            originalList.Add("Task 2");
            var testFile = "test_todos.json";

            try
            {
                // Act - Save
                originalList.Save(testFile);

                // Assert - File exists
                Assert.True(File.Exists(testFile));

                // Act - Load
                var loadedList = new TodoList();
                loadedList.Load(testFile);

                // Assert - Data matches
                Assert.Equal(2, loadedList.Count);
                Assert.Contains(loadedList.Items, item => item.Title == "Task 1");
                Assert.Contains(loadedList.Items, item => item.Title == "Task 2");
            }
            finally
            {
                // Cleanup
                if (File.Exists(testFile))
                    File.Delete(testFile);
            }
        }

        [Fact]
        public void Load_NonExistentFile_ThrowsException()
        {
            var list = new TodoList();
            Assert.Throws<FileNotFoundException>(() => list.Load("nonexistent.json"));
        }
    }
}