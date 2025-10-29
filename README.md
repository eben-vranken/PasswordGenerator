# Password Generator & Strength Checker

A command-line tool for generating secure passwords and checking password strength.

## Features
- Generate passwords with customizable length and character types
- Password strength analysis with detailed feedback
- Cross-platform (Windows, Linux, macOS)

## Installation (Windows)

**Prerequisites:** [.NET 8.0 SDK or Runtime](https://dotnet.microsoft.com/download)

1. Clone the repository:
```
git clone https://github.com/yourusername/password-generator.git
cd password-generator
```

2. Pack and install:
```
dotnet pack -c Release
dotnet tool install --global --add-source ./bin/Release PasswordGenerator
```

3. Use anywhere:
```
password-gen --all -L 20
```

## Usage

Generate a password:
```
password-gen --all -L 20
```

Check password strength:
```
password-gen --check "MyPassword123!"
```

## Options
- `-L, --length <n>` - Password length (default: 16)
- `-u, --uppercase` - Include uppercase letters
- `-l, --lowercase` - Include lowercase letters
- `-n, --numbers` - Include numbers
- `-s, --symbols` - Include symbols
- `--all` - Include all character types
- `--check <password>` - Check password strength
- `-h, --help` - Show help