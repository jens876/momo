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
function meinHandler(id, ereignis, funktion) {
	if(window.addEventlistener)
		document.getElementById(id)
			.addEventListener(ereignis, funktion, false);
	else if(window.attachEvent)
		document.getElementById(id)
			.attachEvent("on" + ereignis, funktion);
}
