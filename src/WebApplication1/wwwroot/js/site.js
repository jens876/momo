function fehlerBehandlung(fehler, datei, zeile) {
	alert("Fehler: " + fehler + "\nDatei: " + datei + "\nZeile: " + zeile);
}

function textInCanvas(Headline) {
	/*
	 * ctCustomer.beginPath(); ctCustomer.moveTo(0, 100); ctCustomer.lineTo(400,
	 * 100); ctCustomer.stroke();
	 */

	ctCustomer.textBaseline = "alphabetic";
	ctCustomer.fillText(Headline, 10, 100);
}

function meinHandler(id, ereignis, funktion) {
	if (window.addEventlistener)
		document.getElementById(id).addEventListener(ereignis, funktion, false);
	else if (window.attachEvent)
		document.getElementById(id).attachEvent("on" + ereignis, funktion);
}

// eventhandler
function check() {
	var f = document.getElementById("idForm");
	f.noValidate = !f.noValidate;
}

function getData(id) {
	// Assign handlers immediately after making the request,
	// and remember the jqXHR object for this request
	var jqxhr = $.ajax(apiUrl + '/' + id).done(function(data) {
		var chart = chartInstance1;
		chart.config.data.datasets[0].data = data.momoBalances;
		chart.config.data.datasets[1].data = data.accountBalances;
		chart.config.data.labels = data.balanceLabels;
		chart.update();
	}).fail(function() {
		alert("error");
	});
	// Perform other work here ...
}

$(document)
		.ready(
				function() {

					window.onerror = fehlerBehandlung;
					// document.write("<p>First!<p>");
					try {
						// document.write("<p>Vor allem!</p>");
						Chart.defaults.global.defaultFontColor = "#000";
						Chart.defaults.global.defaultFontSize = 20;
						Chart.defaults.global.responsive = true;

						var dg = -500;
						var wg = -1000;
						var ml = 800;
						var gruen = "rgba(0,255,0,1)";
						var schwarz = "rgba(0,0,0,1)";
						var rot = "rgba(255,0,0,1)";

						var data = {
							labels : [],
							datasets : [
									{
										label : "Sockelbetrag",
										fill : false,
										lineTension : 0.1,
										// backgroundColor:
										// "rgba(0,100,100,0.4)",
										backgroundColor : gruen,
										// borderColor: "rgba(0,255,0,1)",
										borderColor : gruen,
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
										pointHoverBorderColor : rot,
										pointHoverBorderWidth : 2,
										pointRadius : 1,
										pointHitRadius : 10,
										data : [ ml, ml, ml, ml, ml, ml, ml,
												ml, ml, ml, ml, ml, ml, ml, ml,
												ml, ml, ml, ml, ml, ml, ml, ml,
												ml, ml, ml, ml, ml, ml, ml ],
										spanGaps : false,
									},
									{
										label : "Mit Mo|Mo",
										fill : true,
										lineTension : 0.1,
										backgroundColor : "rgba(75,192,192,1)",
										borderColor : "rgba(75,192,192,1)",
										borderCapStyle : 'square',
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
										data : [],
										spanGaps : false,
									},
									{
										label : "Saldoverlauf",
										fill : true,
										lineTension : 0.1,
										backgroundColor : "rgba(255,100,100,1)",
										borderColor : "rgba(255,255,255,1)",
										borderCapStyle : 'butt',
										borderDash : [],
										borderDashOffset : 0.0,
										borderJoinStyle : 'miter',
										pointBorderColor : "rgba(75,192,192,1)",
										pointBackgroundColor : "#fff",
										pointBorderWidth : 1,
										pointHoverRadius : 5,
										pointHoverBackgroundColor : "rgba(255,100,100,1)",
										pointHoverBorderColor : rot,
										pointHoverBorderWidth : 2,
										pointRadius : 1,
										pointHitRadius : 10,
										data : [],
										spanGaps : false,
									},
									{
										label : "Dispowarnung",
										fill : false,
										lineTension : 0.1,
										backgroundColor : schwarz,
										borderColor : schwarz,
										borderCapStyle : 'butt',
										borderDash : [],
										borderDashOffset : 0.0,
										borderJoinStyle : 'miter',
										borderWidth : 2,
										pointBorderColor : schwarz,
										pointBackgroundColor : "#fff",
										pointBorderWidth : 2,
										pointHoverRadius : 5,
										pointHoverBackgroundColor : "rgba(255,100,100,0.4)",
										pointHoverBorderColor : rot,
										pointHoverBorderWidth : 2,
										pointRadius : 1,
										pointHitRadius : 10,
										data : [ dg, dg, dg, dg, dg, dg, dg,
												dg, dg, dg, dg, dg, dg, dg, dg,
												dg, dg, dg, dg, dg, dg, dg, dg,
												dg, dg, dg, dg, dg, dg, dg ],
										spanGaps : false,
									},
									{
										label : "Schuldenwarnung",
										fill : false,
										lineTension : 0.1,
										backgroundColor : rot,
										borderColor : rot,
										borderCapStyle : 'butt',
										borderDash : [],
										borderDashOffset : 0.0,
										borderJoinStyle : 'miter',
										pointBorderColor : rot,
										pointBackgroundColor : "#fff",
										pointBorderWidth : 2,
										pointHoverRadius : 5,
										pointHoverBackgroundColor : "rgba(255,100,100,0.4)",
										pointHoverBorderColor : rot,
										pointHoverBorderWidth : 2,
										pointRadius : 1,
										pointHitRadius : 10,
										data : [ wg, wg, wg, wg, wg, wg, wg,
												wg, wg, wg, wg, wg, wg, wg, wg,
												wg, wg, wg, wg, wg, wg, wg, wg,
												wg, wg, wg, wg, wg, wg, wg ],
										spanGaps : false,
									} ]
						};

						var ctxChartAction = document
								.getElementById("chartAction");

						chartInstance1 = new Chart(ctxChartAction, {
							type : 'line',
							data : data,
							options : {
								responsive : false
							}
						});

					} catch (e) {
					}

					getData('plain');
					$('#idCheck1').click(getDependingData);
					$('#idCheck2').click(getDependingData);
				});

function getDependingData() {
	var checkbox1Checked = $('#idCheck1')[0].checked;
	var checkbox2Checked = $('#idCheck2')[0].checked;
	if (checkbox1Checked && checkbox2Checked) {
		getData('givetake');
	} else if (checkbox1Checked) {
		getData('take');
	} else if (checkbox2Checked) {
		getData('give');
	} else {
		getData('plain');
	}
};