function drawSalesChart(labels, data) {
    const ctx = document.getElementById('salesChart').getContext('2d');
if (window.salesChart) {
    window.salesChart.destroy(); // Очистка предыдущей диаграммы
    }
window.salesChart = new Chart(ctx, {
    type: 'line',
data: {
    labels: labels,
datasets: [{
    label: 'Продажи за день',
                data: data.map(v => parseFloat(v)),
fill: false,
borderColor: 'rgb(75, 192, 192)',
tension: 0.1
            }]
        },
options: {
    responsive: true,
plugins: {
    legend: {
    position: 'top'
                },
title: {
    display: true,
text: 'Диаграмма продаж по дням'
                }
            }
        }
    });
}