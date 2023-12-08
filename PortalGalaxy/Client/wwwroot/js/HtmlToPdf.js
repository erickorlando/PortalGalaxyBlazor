export function generateAndDownloadPdf(htmlOrElement, filename) {
    const doc = new jspdf.jsPDF({
        orientation: 'p',
        unit: 'pt',
        format: 'a4'
    });

    return new Promise((resolve, reject) => {
        doc.html(htmlOrElement, {
            callback: doc => {
                doc.save(filename);
                resolve();
            }
        });
    });
}

export function generatePdf(htmlOrElement) {
    const doc = new jspdf.jsPDF();
    return new Promise((resolve, reject) => {
        doc.html(htmlOrElement, {
            callback: doc => {
                const output = doc.output("arraybuffer");
                resolve(new Uint8Array(output));
            }
        });
    });
}