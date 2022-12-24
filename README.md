# CoinpaprikaApi
![Coinpaprika Logo](https://raw.githubusercontent.com/ByronAP/CoinpaprikaApi/dev/coinpaprika-logo-banner-256x64.png)
## Coinpaprika API Library for .NET

[![Nuget](https://img.shields.io/nuget/v/CoinpaprikaAPI)](https://www.nuget.org/packages/CoinpaprikaAPI)
[![](https://img.shields.io/static/v1?label=Sponsor&message=%E2%9D%A4&logo=GitHub&color=%23fe8e86)](https://github.com/sponsors/ByronAP)

[![Codacy Badge](https://app.codacy.com/project/badge/Grade/4597bd69581d4039ae591a161fa43f83)](https://www.codacy.com/gh/ByronAP/CoinpaprikaApi/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=ByronAP/CoinpaprikaApi&amp;utm_campaign=Badge_Grade)
[![CodeQL](https://github.com/ByronAP/CoinpaprikaApi/actions/workflows/codeql.yml/badge.svg)](https://github.com/ByronAP/CoinpaprikaApi/actions/workflows/codeql.yml)
[![Tests](https://github.com/ByronAP/CoinpaprikaApi/actions/workflows/dev_test_dotnet.yml/badge.svg)](https://github.com/ByronAP/CoinpaprikaApi/actions/workflows/dev_test_dotnet.yml)

[Coinpaprika API Documentation](https://api.coinpaprika.com/)

[Library Documentation](https://byronap.github.io/CoinpaprikaApi_docs)

### Features

+   Supports all API calls (except changelog)
+   Method names and locations match API
+   Concrete classes
+   Fully asynchronous
+   Compatible with dependency injection and logging
+   Integrated response caching
+   Easier to use then other libraries
+   Changelog endpoint is not implemented (no way for me to test)


Warning: If you don't have an API key Coinpaprika has a ridiculously low rate limit.


Just create an instance of 'CoinpaprikaClient' and start making calls.
