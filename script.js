async function generateQRCode() {
  const text = document.getElementById("text-input").value;

  if (!text) {
    alert("Please enter text to generate a QR code.");
    return;
  }

  const response = await fetch(
    "http://localhost:5133/api/QRCodeApi/generate",
    {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ text: text }),
    }
  );

  if (response.ok) {
    const result = await response.json();
    const img = document.getElementById("qr-code-image");
    img.src = result.imageBase64;
  } else {
    alert("Failed to generate QR code");
  }
}
