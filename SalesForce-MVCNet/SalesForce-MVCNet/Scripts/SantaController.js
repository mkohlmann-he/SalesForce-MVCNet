// NAVIGATION: On Page Load, Show the first tab and hide all the others
$(document).ready(function () {
    $("#DivChildName").show();
    $("#DivChildAge").hide();
    $("#DivParentName").hide();
    $("#DivEmailAddress").hide();
    $("#DivGiftQuestion1").hide();
    $("#DivGiftQuestion2").hide();
    $("#DivRecommendationQuestion").hide();
    $("#DivCountry").hide();
    $("#DivState").hide();
    $("#DivCity").hide();
    $("#DivSurveyResponses").hide();
    $("#DivAcceptedRecommendations").hide();
    $("#DivSubmit").hide();
});

// NAVIGATION: On ButtonChildName click, Show the Child Age question
$(document).ready(function () {
    $("#ButtonChildName").click(function () {
        $("#DivChildName").hide();
        $("#DivChildAge").show();
        $("#DivParentName").hide();
        $("#DivEmailAddress").hide();
        $("#DivGiftQuestion1").hide();
        $("#DivGiftQuestion2").hide();
        $("#DivRecommendationQuestion").hide();
        $("#DivCountry").hide();
        $("#DivState").hide();
        $("#DivCity").hide();
        $("#DivSurveyResponses").hide();
        $("#DivAcceptedRecommendations").hide();
        $("#DivSubmit").hide();
    });
});

// NAVIGATION: On ButtonChildAge click, Show the Parent Name question after that
$(document).ready(function () {
    $("#ButtonChildAge").click(function () {
        $("#DivChildName").hide();
        $("#DivChildAge").hide();
        $("#DivParentName").show();
        $("#DivEmailAddress").hide();
        $("#DivGiftQuestion1").hide();
        $("#DivGiftQuestion2").hide();
        $("#DivRecommendationQuestion").hide();
        $("#DivCountry").hide();
        $("#DivState").hide();
        $("#DivCity").hide();
        $("#DivSurveyResponses").hide();
        $("#DivAcceptedRecommendations").hide();
        $("#DivSubmit").hide();
    });
});


// NAVIGATION: On ButtonParentName click, Show the Email Address question after that
$(document).ready(function () {
    $("#ButtonParentName").click(function () {
        $("#DivChildName").hide();
        $("#DivChildAge").hide();
        $("#DivParentName").hide();
        $("#DivEmailAddress").show();
        $("#DivGiftQuestion1").hide();
        $("#DivGiftQuestion2").hide();
        $("#DivRecommendationQuestion").hide();
        $("#DivCountry").hide();
        $("#DivState").hide();
        $("#DivCity").hide();
        $("#DivSurveyResponses").hide();
        $("#DivAcceptedRecommendations").hide();
        $("#DivSubmit").hide();
    });
});

// NAVIGATION: On ButtonEmailAddress click, Show the First Request question after that
$(document).ready(function () {
    $("#ButtonEmailAddress").click(function () {
        if (is_email($("#emailAddress").val()))
        {
        
            $("#DivChildName").hide();
            $("#DivChildAge").hide();
            $("#DivParentName").hide();
            $("#DivEmailAddress").hide();
            $("#DivGiftQuestion1").show();
            $("#DivGiftQuestion2").hide();
            $("#DivRecommendationQuestion").hide();
            $("#DivCountry").hide();
            $("#DivState").hide();
            $("#DivCity").hide();
            $("#DivSurveyResponses").hide();
            $("#DivAcceptedRecommendations").hide();
            $("#DivSubmit").hide();
        
        }
        else
        {
            $("#emailValidationResponse").text("psst! Please enter a valid email address, so I know where to send this information to later...")

        };
    });
});

// NAVIGATION: On ButtonCountry click, Show the State question after that
$(document).ready(function () {
    $("#ButtonCountry").click(function () {
        $("#DivChildName").hide();
        $("#DivChildAge").hide();
        $("#DivParentName").hide();
        $("#DivEmailAddress").hide();
        $("#DivGiftQuestion1").hide();
        $("#DivGiftQuestion2").hide();
        $("#DivRecommendationQuestion").hide();
        $("#DivCountry").hide();
        $("#DivState").show();
        $("#DivCity").hide();
        $("#DivSurveyResponses").hide();
        $("#DivAcceptedRecommendations").hide();
        $("#DivSubmit").hide();
    });
});

// NAVIGATION: On ButtonState click, Show the City question after that
$(document).ready(function () {
    $("#ButtonState").click(function () {
        $("#DivChildName").hide();
        $("#DivChildAge").hide();
        $("#DivParentName").hide();
        $("#DivEmailAddress").hide();
        $("#DivGiftQuestion1").hide();
        $("#DivGiftQuestion2").hide();
        $("#DivRecommendationQuestion").hide();
        $("#DivCountry").hide();
        $("#DivState").hide();
        $("#DivCity").show();
        $("#DivSurveyResponses").hide();
        $("#DivAcceptedRecommendations").hide();
        $("#DivSubmit").hide();
    });
});

// NAVIGATION: On ButtonCity click, Show the Submit Button question after that
$(document).ready(function () {
    $("#ButtonCity").click(function () {
        $("#DivChildName").hide();
        $("#DivChildAge").hide();
        $("#DivParentName").hide();
        $("#DivEmailAddress").hide();
        $("#DivGiftQuestion1").hide();
        $("#DivGiftQuestion2").hide();
        $("#DivRecommendationQuestion").hide();
        $("#DivCountry").hide();
        $("#DivState").hide();
        $("#DivCity").hide();
        $("#DivSurveyResponses").hide();
        $("#DivAcceptedRecommendations").hide();
        $("#DivSubmit").show();
    });
});


// NAVIGATION AND APPEND: On ButtonFirstRequest click, Append the data to the SurveyResponses Box. Show the Second Request question after that
$(document).ready(function () {
    $("#ButtonFirstRequest").click(function () {
        $("#DivChildName").hide();
        $("#DivChildAge").hide();
        $("#DivParentName").hide();
        $("#DivEmailAddress").hide();
        $("#DivGiftQuestion1").hide();
        $("#DivGiftQuestion2").show();
        $("#DivRecommendationQuestion").hide();
        $("#DivCountry").hide();
        $("#DivState").hide();
        $("#DivCity").hide();
        $("#DivSurveyResponses").hide();
        $("#DivAcceptedRecommendations").hide();
        $("#DivSubmit").hide();
        $("#SurveyResponses").val($("#tbFirst_Request").val());
        
    });
});

// NAVIGATION AND APPEND: On ButtonSecondRequest click, Append the data to the SurveyResponses Box. Show the Recommendation question after that.
$(document).ready(function () {
    $("#ButtonSecondRequest").click(function () {
        $("#DivChildName").hide();
        $("#DivChildAge").hide();
        $("#DivParentName").hide();
        $("#DivEmailAddress").hide();
        $("#DivGiftQuestion1").hide();
        $("#DivGiftQuestion2").hide();
        $("#DivRecommendationQuestion").show();
        $("#DivCountry").hide();
        $("#DivState").hide();
        $("#DivCity").hide();
        $("#DivSurveyResponses").hide();
        $("#DivAcceptedRecommendations").hide();
        $("#DivSubmit").hide();
        $("#SurveyResponses").val($("#SurveyResponses").val() +"|"+ $("#tbSecond_Request").val());
    });
});


// NAVIGATION AND APPEND: On ButtonRecommendation click, Append the data to the AcceptedRecommendations Box. Show the Country question after that.
$(document).ready(function () {
    $("#ButtonRecommendation").click(function () {
        $("#DivChildName").hide();
        $("#DivChildAge").hide();
        $("#DivParentName").hide();
        $("#DivEmailAddress").hide();
        $("#DivGiftQuestion1").hide();
        $("#DivGiftQuestion2").hide();
        $("#DivRecommendationQuestion").hide();
        $("#DivCountry").show();
        $("#DivState").hide();
        $("#DivCity").hide();
        $("#DivSurveyResponses").hide();
        $("#DivAcceptedRecommendations").hide();
        $("#DivSubmit").hide();
        $("#AcceptedRecommendations").val($("#tbRecommendation").val());
    });
});


function is_email(email) {
    var emailReg = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
    return emailReg.test(email);
}


$('body').on('keydown', 'input', function (event) {
    if (event.which == 13) {
        event.preventDefault();
    }
});

