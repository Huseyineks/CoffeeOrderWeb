const { event } = require("jquery");

function openModal(data) {
   
    
    $(".modal").show();
    var menuId = $("#ModalButton-" + data).data('menuid');
 
 
    var image = $("#ModalButton-" + data).data('image');
    var stringForm = " " + image;
    $("#MenuIdInput").val(menuId);
    $("#ModalImage").attr("src", stringForm);
    
    
    
   
   
    
    

}
function closeModal() {
    $(".modal").hide();
   
    clearModal();

}
function clearModal() {
    $(".form-check-input").prop("checked", false);
    $("#Note").val("");
}
