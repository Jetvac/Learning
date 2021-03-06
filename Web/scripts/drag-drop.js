$(document).ready(function () {
    var file;

    let dropField = document.getElementById('drag-n-drop-area');
    ['dragenter', 'dragover', 'dragleave', 'drop'].forEach(eventName => {
        dropField.addEventListener(eventName, preventDefaults, false)
    })

    dropField.addEventListener('drop', handleDrop, false)

    function preventDefaults(e) {
        e.preventDefault()
        e.stopPropagation()
    }

    function handleDrop(e) {
        let dt = e.dataTransfer
        let files = dt.files

        handleFiles(files);
    }

    function handleFiles(files) {
        files = [...files]
        files.forEach(appendFile)

    }

    // convert file to html structure and paste it into gallery
    function appendFile(file) {
        let reader = new FileReader()
        reader.readAsDataURL(file)
        reader.onloadend = function () {
            console.log(reader.result);
            file = reader.result;
        }
    }

    function showUploadError() {
        var errorSpan = document.getElementById('upload-image-error');
        errorSpan.style.display = "block";
    }

    function hideUploadError() {
        var errorSpan = document.getElementById('upload-image-error');
        errorSpan.style.display = "none";
    }
});