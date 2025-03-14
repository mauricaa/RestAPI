const API_BASE_URL = 'https://localhost:7268/numbers';

async function incrementNumber() {
    const inputElement = document.getElementById('incrementNumber');
    const number = parseInt(inputElement.value);

    if (isNaN(number)) {
        console.error('Ungültige Eingabe: Bitte eine Zahl eingeben.');
        return;
    }

    try {
        const response = await fetch(`${API_BASE_URL}/increment`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(number),
        });

        if (!response.ok) throw new Error('Serverantwort war nicht erfolgreich.');

        const data = await response.json();
        document.getElementById('incrementResult').textContent = `Erhöhte Zahl: ${data}`;
    } catch (error) {
        console.error('Fehler beim Increment:', error);
    }
}

async function calculateSum() {
    const zahlA = parseInt(document.getElementById('zahlA').value);
    const zahlB = parseInt(document.getElementById('zahlB').value);

    if (isNaN(zahlA) || isNaN(zahlB)) {
        console.error('Ungültige Eingabe: Bitte zwei Zahlen eingeben.');
        return;
    }

    const sumData = { ZahlA: zahlA, ZahlB: zahlB };

    try {
        const response = await fetch(`${API_BASE_URL}/Sum`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(sumData),
        });

        if (!response.ok) throw new Error('Serverantwort war nicht erfolgreich.');

        const data = await response.json();
        document.getElementById('sumResult').textContent = `Summe: ${data}`;
    } catch (error) {
        console.error('Fehler beim Berechnen der Summe:', error);
    }
}
