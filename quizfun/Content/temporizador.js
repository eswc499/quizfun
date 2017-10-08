
function start(){
   
   if ((contad - 1) >= 0){
    contad -= 1;
    if (contad == 0) {
     contad = "0";
    }else if(contad < 10){
	   contad = "0"+ contad;
    }
    contador.innerText=contad;
    setTimeout('start();', 1000);
}
 }
start();