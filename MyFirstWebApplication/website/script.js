const API_BASE_URL = 'https://localhost:7004/Schule';

async function addSchueler() {
    const name = document.getElementById("name").value;
    const gender = document.getElementById("gender").value;
    const birthDate = document.getElementById("birthDate").value;
    const className = document.getElementById("className").value;

    const response = await fetch(`${API_BASE_URL}/AddSchueler`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ name, gender, birthDate, className }) //konvertiert in JSON
    });
    const result = await response.json();
    document.getElementById("output").innerText = `Schüler hinzugefügt: ${JSON.stringify(result)}`;
}

async function getAllSchueler() {   //sendet HTTP GET anfrage
    const response = await fetch(`${API_BASE_URL}/GetAllSchueler`);
    const result = await response.json();   //wartet auf antwort
    document.getElementById("output").innerText = `Alle Schüler: ${JSON.stringify(result, null, 2)}`; //gibt als JSON aus
}

async function getSchuelerByClass() {
    const className = document.getElementById("searchClass").value; //holt Klassennamen aus HTML Input feld
    const response = await fetch(`${API_BASE_URL}/GetAllSchueler`); //ruft alle SChüler von der api ab
    const students = await response.json();
    const filtered = students.filter(s => s.className === className); //filtert
    document.getElementById("output").innerText = `Schüler in Klasse ${className}: ${JSON.stringify(filtered, null, 2)}`; //zeigt gefilterte liste im output
}

async function checkClassroomCapacity() {
    const className = document.getElementById("checkClass").value; //holt klassenraum und sitzplätze aus HTML Inputs
    const roomSeats = parseInt(document.getElementById("roomSeats").value);
    const response = await fetch(`${API_BASE_URL}/GetAllSchueler`);
    const students = await response.json();
    const classSize = students.filter(s => s.className === className).length; //zählt
    document.getElementById("output").innerText = classSize <= roomSeats ? "Die Klasse passt in den Raum." : "Zu wenig Plätze im Raum.";
}

async function getStats() {
    const ageResponse = await fetch(`${API_BASE_URL}/AvgAge`);
    const avgAge = await ageResponse.json();

    const genderResponse = await fetch(`${API_BASE_URL}/Gender`);
    const genderStats = await genderResponse.json();

    document.getElementById("output").innerText = `Durchschnittsalter: ${avgAge}\nMännlich: ${genderStats.Maennlich}, Weiblich: ${genderStats.Weiblich}`;
}
