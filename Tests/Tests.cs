namespace Tests
{
    [TestClass]
    public class Tests
    {
        private readonly Helpers _helpers;

        public Tests()
        {
            _helpers = new Helpers();
        }

        [TestMethod]
        public void ExampleTest()
        {
            // Runs the app and returns the output from Console.WriteLine
            string capturedStdOut = _helpers.CapturedStdOut(_helpers.RunApp);
            Console.WriteLine(capturedStdOut);

            // create a variable to return current date time for uk to assert the response
            var ukDateTime = DateTime.Now;
            var dateTimeFormatter = "dddd dd MMMM yyyy HH:mm:ss";
            var ukTime = ukDateTime.ToString(dateTimeFormatter);

            //Edit: Assert that the captured output contains the expected UK time string
            Assert.IsTrue(capturedStdOut.Contains("UK Time: "+ukTime));
        }


        [TestMethod]
        public void Test_UKAndCanadaTimesAreDisplayed()
        {
            // AC: Must display the current time for the UK and Canada

            // Runs the app and returns the output from Console.WriteLine
            string capturedOutput = _helpers.CapturedStdOut(_helpers.RunApp);

            // Run an assertion on the captured output for UK time and Canada time
            StringAssert.Contains(capturedOutput, "UK Time: ");
            StringAssert.Contains(capturedOutput, "Canada Time: ");
        }

        [TestMethod]
        public void Test_TimeDifferenceMessage_IsDisplayedCorrectly()
        {
            //AC: Must display the difference in time between the UK and Canada

            // Runs the app and returns the output from Console.WriteLine
            string capturedOutput = _helpers.CapturedStdOut(_helpers.RunApp);

           Console.WriteLine($"{capturedOutput}");

            // Check if the time difference message is present in the output
            Assert.IsTrue(capturedOutput.Contains("behind of you") || capturedOutput.Contains("ahead of Canada"),
                "Output should contain a message indicating the time difference between UK and Canada.");

            // Validate that the time difference is displayed in minutes
            StringAssert.Contains(capturedOutput, "300 minutes behind", "Expected time difference in minutes (e.g., '300 minutes ahead of Canada').");
        }

        [TestMethod]
        public void Test_CorrectDateTimeFormat()
        {
            // Runs the app and returns the output from Console.WriteLine
            string capturedOutput = _helpers.CapturedStdOut(_helpers.RunApp);

            //AC: Date and time must be displayed in the format 'Monday 1 January 2023 17:00:00'
            // Define expected date time format pattern (e.g., "Monday 11 November 2024 13:47:17")
            string pattern = @"\b\w+ \d{2} \w+ \d{4} \d{2}:\d{2}:\d{2}\b";

            // Verify format for both UK and Canada times
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(pattern);

            var matches = regex.Matches(capturedOutput);

            // Assert that both UK and Canada date-time formats are matched
            Assert.AreEqual(2, matches.Count, "Expected two date-time entries in the specified format (one for UK and one for Canada).");
        }

    }
}