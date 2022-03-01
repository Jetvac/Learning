$(document).ready(function () {
    function openTab(tabName) {
        var i, tabcontent;
            
        tabcontent = document.getElementsByClassName("active-place__tab");
        for (i = 0; i < tabcontent.length; i++) {
            tabcontent[i].className = tabcontent[i].className.replace(" active-tab", "");
        }
        
        document.getElementById(tabName).className += " active-tab";
    }
    $('#courses-button').click(function(e) {
        openTab('course-panel');
    });
    $('#add-course__navigate-button').click(function(e) {
        openTab('course-add-panel');
    });
});