# Appointment Booking System

## 1. Download the Project

First, download the project from the GitHub repository.

- **URL**: [AppointmentBookingSystem Repository](https://github.com/bhargavdakwala/AppointmentBookingSystem/tree/master)

### Steps to Download:
1. **Go to the URL above**: Visit the GitHub repository in your browser.
2. **Download the project**:
    - Click on the green "Code" button (located near the top right).
    - Choose "Download ZIP".
    - Extract the ZIP file to a directory on your local machine.

Alternatively, if you have Git installed, you can clone the repository using the following command:
```bash
git clone https://github.com/bhargavdakwala/AppointmentBookingSystem.git
# Project Setup and API Testing

## 2. Open the Project in Visual Studio

You can open the project in Visual Studio.

### Steps to Open the Project in Visual Studio:
1. Launch **Visual Studio**.
2. Go to `File > Open > Project/Solution`.
3. Browse to the folder where you extracted or cloned the repository, and select the appropriate solution file (usually a `.sln` file) if it's a .NET-based project.

---

## 3. Build the Project

After opening the project, you need to build it.

### Steps to Build:
1. In Visual Studio, click on the **Build** menu at the top.
2. Select **Build Solution** or press `Ctrl + Shift + B`.

---

## 4. Run the Project

You can run the project as follows:

- **Run without debugging**: Press `Ctrl + F5`.
- **Run with debugging**: Click on the **Start Debugging** button or press `F5`.

---

## 5. Testing the API

To test the API, use the following JSON as the payload in the API endpoint:

```json
{
  "date": "2024-05-03",
  "products": ["SolarPanels", "Heatpumps"],
  "language": "German",
  "rating": "Gold"
}
