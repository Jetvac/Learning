$(document).ready(function () {
    let base64File;

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
            base64File = reader.result;
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

    $('#course-add-button').click(function (e) {
        e.preventDefault();

        var courseName = $('#course-name').val();
        var startDate = $('#start-date').val();
        var endDate = $('#end-date').val();
        var educationalOrganisationID = $('#education-place-selector').val();
        var hoursCount = $('#hours-count').val();

        $.ajax({
            url: `${IP}/AddCompletedCourse`,
            type: `POST`,
            contentType: `application/text; charset=utf-8`,
            data: `${courseName}\n${startDate}\n${endDate}\n${educationalOrganisationID}\n${hoursCount}\n${base64File}`,
            success: function (response) {
                console.log(response);
            }
        });
    });
});