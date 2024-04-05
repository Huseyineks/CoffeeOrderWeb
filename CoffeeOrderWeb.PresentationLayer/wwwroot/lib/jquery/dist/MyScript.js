const { event } = require("jquery");

function openModal(data) {
    $(".modal").show();
    var menuId = $("#ModalButton-"+data).data('menuid');
    $("#MenuIdInput").val(menuId);
    
    

}
function closeModal() {
    $(".modal").hide();
   
    clearModal();

}
function clearModal() {
    $(".form-check-input").prop("checked", false);
    $("#Note").val("");
}
