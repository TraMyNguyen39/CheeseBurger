const selectBox = document.querySelector('select[name="combobox_Item"]');
const fromDate = document.querySelector('input[name="fromDate"]');
const toDate = document.querySelector('input[name="toDate"]');

function updateFormFields() {
    if (selectBox.value === 'day') {      
        fromDate.type = 'date';
        toDate.type = 'date';
    } else if (selectBox.value === 'month') {       
        fromDate.type = 'month';
        toDate.type = 'month';
    } else if (selectBox.value === 'year') {      
        fromDate.type = 'number';
        toDate.type = 'number';
    }
}

updateFormFields();

selectBox.addEventListener('change', updateFormFields);


/* Get the canvas element and context */
var ctx = document.getElementById('myChart').getContext('2d');

/* Define the data for the chart */
var data = {
	labels: ['January', 'February', 'March', 'April', 'May'],
	datasets: [
		{
			label: 'Profit',
			//backgroundColor: '#FA5230',
			borderColor: 'rgba(255, 99, 132, 1)',
			fill: false,
			//borderWidth: 1,
			data: [50, 60, 40, 40, 80],
			tension: 0.1

		},
		{
			label: 'Funds',
			//backgroundColor: '#E3E7FC',
			//borderWidth: 1,
			data: [20, 40, 30, 20, 50],
			fill: false,
			tension: 0.1,
			borderColor: 'rgba(75, 192, 192, 1)'
			//borderRadius: [0, 10, 10, 0],
		}
	]
};

/* Define the options for the chart */
var options = {
	scales: {
		yAxes: [{
			ticks: {
				beginAtZero: true
			}
		}]
	},
};

/* Create the chart */
var myChart = new Chart(ctx, {
    type: 'line',
    data: data,
    options: options
}); 