//var audio, muteBtn;
//function initAudioPlayer() {
//	audio = new Audio();
//	audio.src = "musics/bells.mp3";
//	audio.loop = true;
//	audio.play();
//	// Set object references

//	muteBtn = document.getElementById("muteBtn");
//	// Add Event Handling

//	muteBtn.addEventListener("click", mute);
//	// Functions

//	function mute() {
//		if (audio.muted) {
//			audio.muted = false;
//			muteBtn.style.background = "url(https://image.flaticon.com/icons/svg/204/204287.svg) no-repeat";
//		} else {
//			audio.muted = true;
//			muteBtn.style.background = "url(https://image.flaticon.com/icons/svg/148/148757.svg) no-repeat";
//		}
//	}
//}
//window.addEventListener("load", initAudioPlayer);
var iconClass = document.getElementById("iconClass")
var bells = document.getElementById("bells");
function musicPlay() {
    if (iconClass.classList.contains("fa-play")) {
        
        bells.play();
       
        iconClass.classList.remove("fa-play");
        iconClass.classList.add("fa-pause");
        
    }
    else {
        bells.pause();
        iconClass.classList.remove("fa-pause");
        iconClass.classList.add("fa-play");


    }
    
}


