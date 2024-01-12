Chart.register(ChartDataLabels);

window.setup = (id, config) => {
    var ctx = document.getElementById(id).getContext('2d');

    var myChart = Chart.getChart(id);
    if (myChart !== undefined) {
        myChart.destroy();
    }

    myChart = new Chart(ctx, config);
}