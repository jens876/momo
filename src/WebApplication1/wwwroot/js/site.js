function fehlerBehandlung(fehler, datei, zeile) {
    alert("Fehler: " + fehler + "\nDatei: " + datei
        + "\nZeile: " + zeile);
}
function textInCanvas(Headline) {
    ctCustomer.beginPath();
    ctCustomer.moveTo(0, 100);
    ctCustomer.lineTo(400, 100);
    ctCustomer.stroke();

    ctCustomer.textBaseline = "alphabetic";
    ctCustomer.fillText(Headline,10 ,100);
}
