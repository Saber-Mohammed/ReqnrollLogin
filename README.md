# ReqnrollLogin
- This project is developed to demonstrate simple login scenarios using ReqnRoll and NUnit.
- The login feature has 4 scenarios which includes both positive and negative scenarios.
- The project uses dependency injection, Logging, Extent Reports.

# reqnroll-bdd-automation

- A robust BDD automation framework built with C#, leveraging [Reqnroll](https://reqnroll.net/) (SpecFlow fork), Selenium WebDriver, Page Object Model (POM) and Extent reporting.

---

## Key Features

### 1. Reqnroll (formerly Specflow) BDD Framework

- Uses [Reqnroll](https://reqnroll.net/) for Behavior-Driven Development.
- Write feature files in Gherkin syntax for clear, business-readable test scenarios.
- Step definitions are implemented in C# for seamless integration with the application logic.

### 2. Environment Management via Property File

- Environment-specific data (e.g., browser, base URL, credentials) is maintained in a single Appsettings.json file under `resources/`.
- The `Setup` helper class loads these properties at runtime, making it easy to switch environments or update test data without code changes.

### 3. Page Object Model (POM)

- Implements the Page Object Model design pattern for maintainable and reusable UI automation.
- Login page encapsulates its elements and actions.

### 4. Extent Report Integration

- Generates rich, interactive test reports using Extent reports
- Extent report is configured via the ExtentReports NuGet package.

### 5. Logging

- Uses [log4net](https://logging.apache.org/log4net/) for detailed logging.
- Log configuration is managed in Logs/Testlogs.
- Logs are written to the `Logs/` directory in the test output, capturing key events and errors.

### 6. Selenium WebDriver Manager

- Uses [WebDriverManager](https://github.com/rosolko/WebDriverManager.Net) to automatically download and manage browser drivers.
- No manual driver setup required; 
---

## Getting Started

1. **Clone the repository**
3. **Run tests** using your preferred test runner (e.g., Visual Studio Test Explorer, `dotnet test`).
4. **View reports** locally.
