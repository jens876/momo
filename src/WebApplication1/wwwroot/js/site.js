function fehlerBehandlung(fehler, datei, zeile) {
    alert("Fehler: " + fehler + "\nDatei: " + datei
        + "\nZeile: " + zeile);
}

function textInCanvas(Headline) {
/*    ctCustomer.beginPath();
    ctCustomer.moveTo(0, 100);
    ctCustomer.lineTo(400, 100);
    ctCustomer.stroke(); */

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

	// eventhandler
function check() {
	var f = document.getElementById("idForm");
	f.noValidate = !f.noValidate;
}

window.onerror = fehlerBehandlung;
// document.write("<p>First!<p>");
try {
	//document.write("<p>Vor allem!</p>");
	Chart.defaults.global.defaultFontColor = "#F0F";
	Chart.defaults.global.defaultFontSize = 20;
	Chart.defaults.global.responsive = true;

	var cCustomer = document.getElementById("customerInfo");
	var ctCustomer = cCustomer.getContext("2d");
	ctCustomer.fillStyle = "#000000";
	ctCustomer.lineWidth = 1;
	ctCustomer.strokeStyle = "#000000";
	ctCustomer.font = "italic bold 24px Courier";
	var gradient = ctCustomer
			.createLinearGradient(0, 0, cCustomer.width, 0);
	gradient.addColorStop("0", "magenta");
	gradient.addColorStop("0.5", "blue");
	gradient.addColorStop("1.0", "red");
	// Fill with gradient
	ctCustomer.fillStyle = gradient;

	//textInCanvas(ctCustomer);
	textInCanvas("His majesty Henry VIII. (keine Aktion) - vorhandenes Geld");

	var dg = -500;
	var wg = -1000;
	var ml = 800;
	
	var data = {
		labels : [ "01.", "02.", "03.", "04.", "05.", "06.", "07.", "08.",
				"09.", "10.", "11.", "12.", "13.", "14.", "15.", "16.",
				"17.", "18.", "19.", "20.", "21.", "22.", "23.", "24.",
				"25.", "26.", "27.", "28.", "29.", "30.", ],
		datasets : [
				{
					label : "Verlauf mit MoMo",
					fill : true,
					lineTension : 0.1,
					backgroundColor : "rgba(75,192,192,1)",
					borderColor : "rgba(75,192,192,1)",
					borderCapStyle : 'butt',
					borderDash : [],
					borderDashOffset : 0.0,
					borderJoinStyle : 'miter',
					pointBorderColor : "rgba(75,192,192,1)",
					pointBackgroundColor : "#fff",
					pointBorderWidth : 1,
					pointHoverRadius : 5,
					pointHoverBackgroundColor : "rgba(75,192,192,1)",
					pointHoverBorderColor : "rgba(220,220,220,1)",
					pointHoverBorderWidth : 2,
					pointRadius : 1,
					pointHitRadius : 10,
					data : [ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
							0, 0, -50, -30, 0, 0, 0, 0, 0, -200, 0, 0, 0,
							0, 0 ],
					spanGaps : false,
				},
				{
					label : "Saldoverlauf",
					fill : true,
					lineTension : 0.1,
					backgroundColor : "rgba(255,100,100,0.4)",
					borderColor : "rgba(255,255,255,1)",
					borderCapStyle : 'butt',
					borderDash : [],
					borderDashOffset : 0.0,
					borderJoinStyle : 'miter',
					pointBorderColor : "rgba(75,192,192,1)",
					pointBackgroundColor : "#fff",
					pointBorderWidth : 1,
					pointHoverRadius : 5,
					pointHoverBackgroundColor : "rgba(255,100,100,0.4)",
					pointHoverBorderColor : "rgba(255,0,0,1)",
					pointHoverBorderWidth : 2,
					pointRadius : 1,
					pointHitRadius : 10,
					data : [ 2000, 1800, 1800, 1750, 1500, 1271.5, 1269.9,
							703.99, 253.5, 130, 120, 100, 80, 30, -55.55,
							-150, -180, -250, -300, -355, -360, -370, -370,
							-370, -370, -800, -955, -1053, -1199, -1530 ],
					spanGaps : false,
				},
				{
					label : "Sockelbetrag",
					fill : false,
					lineTension : 0.1,
					backgroundColor : "rgba(255,100,100,0.4)",
					borderColor : "rgba(0,255,0,1)",
					borderCapStyle : 'butt',
					borderDash : [],
					borderDashOffset : 0.0,
					borderJoinStyle : 'miter',
					borderWidth : 2,
					pointBorderColor : "rgba(0,255,0,1)",
					pointBackgroundColor : "#fff",
					pointBorderWidth : 2,
					pointHoverRadius : 5,
					pointHoverBackgroundColor : "rgba(255,100,100,0.4)",
					pointHoverBorderColor : "rgba(255,0,0,1)",
					pointHoverBorderWidth : 2,
					pointRadius : 1,
					pointHitRadius : 10,
					data : [ ml, ml, ml, ml, ml, ml,  ml,
						 	ml,  ml, ml, ml, ml, ml, ml, ml,
						 	ml,  ml, ml, ml, ml, ml, ml, ml,
						 	ml,  ml, ml, ml, ml, ml, ml
						   ],
					spanGaps : false,
				},
				{
					label : "Dispogrenze (8%)",
					fill : false,
					lineTension : 0.1,
					backgroundColor : "rgba(255,100,100,0.4)",
					borderColor : "rgba(0,0,0,1)",
					borderCapStyle : 'butt',
					borderDash : [],
					borderDashOffset : 0.0,
					borderJoinStyle : 'miter',
					borderWidth : 2,
					pointBorderColor : "rgba(0,0,0,1)",
					pointBackgroundColor : "#fff",
					pointBorderWidth : 2,
					pointHoverRadius : 5,
					pointHoverBackgroundColor : "rgba(255,100,100,0.4)",
					pointHoverBorderColor : "rgba(255,0,0,1)",
					pointHoverBorderWidth : 2,
					pointRadius : 1,
					pointHitRadius : 10,
					data : [ dg, dg, dg, dg, dg, dg,  dg,
						 	dg,  dg, dg, dg, dg, dg, dg, dg,
						 	dg,  dg, dg, dg, dg, dg, dg, dg,
						 	dg,  dg, dg, dg, dg, dg, dg
						   ],
					spanGaps : false,
				},
				{
					label : "Bloß nicht tiefer (20%)",
					fill : false,
					lineTension : 0.1,
					backgroundColor : "rgba(255,100,100,0.4)",
					borderColor : "rgba(255,0,0,1)",
					borderCapStyle : 'butt',
					borderDash : [],
					borderDashOffset : 0.0,
					borderJoinStyle : 'miter',
					pointBorderColor : "rgba(255,0,0,1)",
					pointBackgroundColor : "#fff",
					pointBorderWidth : 2,
					pointHoverRadius : 5,
					pointHoverBackgroundColor : "rgba(255,100,100,0.4)",
					pointHoverBorderColor : "rgba(255,0,0,1)",
					pointHoverBorderWidth : 2,
					pointRadius : 1,
					pointHitRadius : 10,
					data : [ wg, wg, wg, wg, wg, wg,  wg,
						 	wg,  wg, wg, wg, wg, wg, wg, wg,
						 	wg,  wg, wg, wg, wg, wg, wg, wg,
						 	wg,  wg, wg, wg, wg, wg, wg
						   ],
					spanGaps : false,
				} ]
	};
} catch (e) {
	alert(e);
}
var ctxChartAction = document.getElementById("chartAction");
var ctxChartNoAction = document.getElementById("chartNoAction");

var chartInstance1 = new Chart(ctxChartAction, {
	type : 'line',
	data : data,
	options : {
		responsive : false
	}
});
var chartInstance2 = new Chart(ctxChartNoAction, {
	type : 'bar',
	data : data,
	options : {
		responsive : false
	}
});
meinHandler("idCheck1", "click", check);

