//Hook up the tweet display

$(document).ready(function() {
                           
    $(".countdown").countdown({
                date: "8 November 2023 18:30:00",
                format: "on"
            },
            
            function() {
                // callback function
            });

}); 