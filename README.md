# CompanyFinder

![Contributors][contributors-shield]
![Forks][forks-shield]
![Stargazers][stars-shield]
![Issues][issues-shield]
![License][license-shield]
![LinkedIn][linkedin-shield]

## About The Project

**CompanyFinder** is a comprehensive stock watchlist and dashboard application designed to help users monitor and analyze their favorite companies' stock performance. The platform provides real-time data, customizable watchlists, and insightful analytics to support informed investment decisions.

### Features

- **Real-Time Stock Data**: Access up-to-date stock prices and market trends.
- **Customizable Watchlists**: Create and manage personalized lists of companies to monitor.
- **Interactive Dashboards**: Visualize stock performance through interactive charts and graphs.
- **News Integration**: Stay informed with the latest news related to your watchlisted companies.
- **Alerts & Notifications**: Set up custom alerts for price changes, news updates, and more.

### Built With

- **Front-End**:
  - [.NET Core](https://dotnet.microsoft.com/)
- **Back-End**:
  - [.NET Core](https://dotnet.microsoft.com/)
  - [ASP.NET Web API](https://dotnet.microsoft.com/apps/aspnet/apis)
- **Database**:
  - [SQL Server](https://www.microsoft.com/en-us/sql-server)
- **APIs**:
  - [Alpha Vantage](https://www.alphavantage.co/) for stock data
  - [NewsAPI](https://newsapi.org/) for news integration

## Getting Started

To get a local copy up and running, follow these steps.

### Prerequisites

- **.NET SDK**: [Download Here](https://dotnet.microsoft.com/download)
- **Node.js & npm**: [Download Here](https://nodejs.org/)

### Installation

1. **Clone the repository**:
   ```sh
   git clone https://github.com/zep1994/CompanyFinder.git
   ```

2. **Navigate to the project directory**:
   ```sh
   cd CompanyFinder
   ```

3. **Set up the backend**:
   - Navigate to the API directory:
     ```sh
     cd CompanyFinderAPI
     ```
   - Restore .NET dependencies:
     ```sh
     dotnet restore
     ```
   - Update the `appsettings.json` file with your database connection string and API keys.

4. **Set up the frontend**:
   - Navigate to the client directory:
     ```sh
     cd ../CompanyFinderClient
     ```
   - Install npm dependencies:
     ```sh
     npm install
     ```

5. **Run the application**:
   - Start the backend server:
     ```sh
     cd ../CompanyFinderAPI
     dotnet run
     ```
   - Start the frontend development server:
     ```sh
     cd ../CompanyFinderClient
     npm run dev
     ```

## Usage

- Add companies to your watchlist.
- Monitor real-time stock performance and trends.
- Set up alerts for stock price movements.
- Read financial news related to your selected companies.

## Roadmap

- [ ] Implement user authentication (OAuth2, JWT)
- [ ] Enhance mobile responsiveness
- [ ] Add AI-powered stock recommendations
- [ ] Improve historical data analysis tools

## Contributing

We welcome contributions! Follow these steps:

1. Fork the repository
2. Create a new feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a pull request

## License

Distributed under the MIT License. See `LICENSE.txt` for details.

## Contact

**Thomas Matlock**  
[LinkedIn](https://linkedin.com/in/tmatlockCISA)  
[GitHub](https://github.com/zep1994)

Project Link: [CompanyFinder](https://github.com/zep1994/CompanyFinder)

[contributors-shield]: https://img.shields.io/github/contributors/zep1994/CompanyFinder.svg?style=for-the-badge
[forks-shield]: https://img.shields.io/github/forks/zep1994/CompanyFinder.svg?style=for-the-badge
[stars-shield]: https://img.shields.io/github/stars/zep1994/CompanyFinder.svg?style=for-the-badge
[issues-shield]: https://img.shields.io/github/issues/zep1994/CompanyFinder.svg?style=for-the-badge
[license-shield]: https://img.shields.io/github/license/zep1994/CompanyFinder.svg?style=for-the-badge
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
