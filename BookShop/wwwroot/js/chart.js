function renderChart(ctx, labels, data, groupingType) {
    console.log("Labels:", labels);
    console.log("Data:", data);
    console.log("Grouping Type:", groupingType);

    if (!ctx) {
        console.error("Canvas context is null. Ensure the canvas element exists.");
        return;
    }

    if (window.myChart) {
        window.myChart.destroy(); // Очищаем предыдущий график
    }

    const chartType = groupingType === "day" ? "bar" : "line"; // Гистограмма для дней, линейный график для недель
    window.myChart = new Chart(ctx, {
        type: chartType,
        data: {
            labels: labels,
            datasets: [{
                label: 'Общая сумма продаж',
                data: data,
                backgroundColor: 'rgba(75, 192, 192, 0.2)',
                borderColor: 'rgba(75, 192, 192, 1)',
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
}

window.renderChart = renderChart;