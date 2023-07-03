# RetailWebsiteDiscountCalculator

This is a C# .NET Core program that calculates the net payable amount on a retail website based on different discounts and rules.

How to Run the Code
Install .NET Core if you haven't already.

Clone this repository to your local machine.

Open a terminal or command prompt and navigate to the project directory.

Run the following command to build the project:

````
dotnet build
````
After a successful build, run the following command to execute the program:

````
dotnet run
````
This will display the net payable amount calculated based on the provided bill and user details.

HOW TO RUN THE TESTS
This project includes unit tests to ensure the correctness of the code. To run the tests, follow these steps:

Open a terminal or command prompt and navigate to the project directory (if you haven't already).

Run the following command to execute the tests:

````
dotnet test
````
This will run all the unit tests and display the test results.

HOW TO GENERATE COVERAGE REPORTS
To generate code coverage reports for the tests, you can use a tool like Coverlet.

Install the coverlet.console NuGet package globally by running the following command:

````
dotnet tool install --global coverlet.console
````
After installing the package, navigate to the project directory in a terminal or command prompt.

Run the following command to generate a coverage report in the coverage.xml format:

````
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
````
This command runs the tests and collects the code coverage information.

The coverage report will be generated as coverage.opencover.xml in the project directory.
