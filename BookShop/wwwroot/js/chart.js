window.renderSalesChart = function (dailySalesData) {
    const ctx = document.getElementById('salesChart');

    if (!ctx) return;

    // Удаляем старую диаграмму, если есть
    if (window.salesChartInstance) {
        window.salesChartInstance.destroy();
    }

    const labels = Object.keys(dailySalesData);
    const data = Object.values(dailySalesData);

    window.salesChartInstance = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'Продажи, ₽',
                data: data,
                fill: false,
                borderColor: 'rgb(75, 192, 192)',
                tension: 0.1
            }]
        },
        options: {
            responsive: true,
            scales: {
                x: {
                    ticks: {
                        maxRotation: 90,
                        minRotation: 45
                    }
                },
                y: {
                    beginAtZero: true
                }
            }
        }
    });
};
