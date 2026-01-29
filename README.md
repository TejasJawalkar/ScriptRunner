# ScriptRunner – Desktop SQL Script Execution Tool

ScriptRunner is a Windows desktop application built with C# and .NET designed to execute SQL scripts safely and efficiently across multiple database environments. It supports batching using the `GO` keyword, secure connection profile management, execution history, and detailed logging.

This tool is ideal for developers and DBAs who frequently run SQL scripts and want a reliable, repeatable workflow.

---

## ⭐ Features

- Execute SQL scripts against multiple database profiles  
- Automatic script batching using the `GO` separator  
- Create, update, delete & test database connection profiles  
- Secure encrypted storage of connection strings  
- Execution history with timestamps, batch count & errors  
- Detailed error tracing and logging  
- Extensible provider architecture (SQL Server supported, Oracle optional)  
- User-friendly WinForms interface  

---

## 🧱 Architecture Overview

ScriptRunner follows a clean, layered architecture:

UI (WinForms) → Core (Logic & Providers) → Infrastructure (EF Core persistence)

---

## 📂 Project Structure

ScriptRunner/  
│── docs/  
│── src/  
│── README.md  
│── ScriptRunner.sln  

---

## 🚀 Getting Started

### Prerequisites
- .NET 8 SDK  
- Visual Studio 2022  
- SQL Server (Express/Developer/LocalDB)

### Steps
1. Clone repo  
2. Open solution  
3. Set ScriptRunner.WinForms as startup  
4. Run (F5)

