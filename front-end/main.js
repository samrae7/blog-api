
function handleClick() {
  var upload = document.getElementById('upload');
  var file = upload.files[0];
  console.log("file", file);
  // Assuming jQuery
  $.ajax('http://localhost:5000/api/s3upload', {
    method: "POST",
    data: file,
    success: callback,
    processData: false,
    contentType: false
  });
}

function callback() {
  console.log("success");
}

