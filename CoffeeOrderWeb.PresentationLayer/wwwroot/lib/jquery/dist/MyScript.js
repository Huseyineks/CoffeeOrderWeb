const { event } = require("jquery");

function openBasketModal(data) {


    $("#Modal1-" + data).show();
    
       


}


function openModal(data) {
   

    $("#Modal1-" + data).show();
   
    
    
    
   
   
    
    

}
function closeModal() {
    $(".modal").hide();

    

}
function clearModal() {
    $(".form-check-input").prop("checked", false);
    $("#Note").val("");
}

function showForm() {

    $('#hiddenForm').show();

}

function hideForm() {

    $("#CCName").val("");
    $("#CCNumber").val("");
    $("#CCDate").val("");
    $("#CCCvv").val("");
    $("#IsSaved").prop("checked", false);

    $("#hiddenForm").hide();


}



