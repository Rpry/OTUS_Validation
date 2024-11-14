document.getElementById("upload").addEventListener("click", api, false);
const fileInput = document.getElementById("file-input");

function api() {
    const url = "https://localhost:5003/file";
    const xhr = new XMLHttpRequest();
    const formData = new FormData();
    debugger;
    formData.append("file1", fileInput.files[0]);
    xhr.open("POST", url, false);
    xhr.send(formData);
    //return false;
}