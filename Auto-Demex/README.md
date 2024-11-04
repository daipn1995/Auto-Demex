# Demex Automation Testing

Automated UI test for **[Demex](dem.exchange)** based on **[Atata Framework](https://atata.io)**.

### 1. Framework Structure

```
Auto-Demex/
|- Configuration/               
	|- AtataConfiguration.cs		// Contains all of global configurations for SUT(System Under Tests)
|- Extension/									
	|- {extension}.crx				// Defines extension files
|- Pages/							
	|- BasePage.cs					// Define base methods which will be used in every pages
	|- {PageName}Page.cs			// Naming convention for pages
|- Tests/
	|- {Name}Tests.cs				// Naming convention for step definitions
|- README.md
|- TestBase.cs						// Define hooks and common method of tests
```


### 2. Dependencies

- Webdriver Interaction - [Atata framework](https://atata.io)
- Test Runner - [NUnit](https://nunit.org/)

### 3. Coding Standard

- TBD...

### 4. Elimination scope

- Common list:
  - Select, cut, copy, paste, drag, or drop text or object
  - Change device network, GPS, time, or timezone configuration
  - 5xx server errors
  - Page loading
  - Pagination (loading more, next page, previous page)

- Other:
	- Unstable features
	- UI/UX cases such as suitable animations, size, color, layout, PDF file content, chart.
	- Data limitation (TBD)
	- For elimination feature - screen by screen (TBD)

### 5. Run test

- Run from IDE: Go to Visual Studio 2022 > Open Test Explorer > Right click > Run all tests
