function drawSalesChart(labels, data) {
    console.log("Labels:", labels);
    console.log("Data:", data);

    const canvas = document.getElementById('salesChart');
    if (!canvas) {
        console.error("Canvas element with id 'salesChart' not found.");
        return;
    }

    const ctx = canvas.getContext('2d');
    if (!ctx) {
        console.error("Could not get 2D context from canvas.");
        return;
    }

    // Уничтожаем существующую диаграмму, если она есть
    if (window.salesChart && typeof window.salesChart.destroy === 'function') {
        window.salesChart.destroy();
    }

    window.salesChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                label: 'Сумма продаж',
                data: data,
                backgroundColor: 'rgba(75, 192, 192, 0.2)',
                borderColor: 'rgba(75, 192, 192, 1)',
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: { display: true },
                tooltip: { enabled: true }
            },
            scales: {
                x: {
                    title: { display: true, text: 'Дата' }
                },
                y: {
                    title: { display: true, text: 'Сумма продаж' },
                    beginAtZero: true
                }
            }
        }
    });
}