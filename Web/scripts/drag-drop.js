// drag and drop

document.addEventListener("DOMContentLoaded", () => {
    let dropField = document.getElementById('drop-field');
    ['dragenter', 'dragover', 'dragleave', 'drop'].forEach(eventName => {
        dropField.addEventListener(eventName, preventDefaults, false)
    })

    dropField.addEventListener('drop', handleDrop, false)
});

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
    reader.onloadend = function() {
        let image = document.createElement('img')
        image.src = reader.result

        image.onload = function() {
            // check image format
            if (file.type != "image/png" || file.size > 10485760 || this.width < 800 || this.height < 600) {
                showUploadError();
            } else {
                 // init structure
                image.classList += "product-popup__list-photo-image";
                document.getElementById('photo-gallery-list').appendChild(image);
                hideUploadError();
            }
        }
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