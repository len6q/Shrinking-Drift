mergeInto(LibraryManager.library, {

ShowADS: function (){
		ysdk.adv.showFullscreenAdv({
			callbacks: {
				onClose: function(wasShown) {
					// some action after close
				},
				onError: function(error) {
					console.log(error);
					// some action on error
				}
			}
		})
	},
	
SaveExtern: function (date){
		var dateString = UTF8ToString(date);
		var myobj = JSON.parse(dateString);
		player.setData(myobj);
	},

LoadExtern: function (){
		player.getData().then(_date => {
			const myJSON = JSON.stringify(_date);
			myGameInstance.SendMessage("Settings", "Load", myJSON);
		});
	},	
	
SetToLeaderboard: function (value){
		ysdk.getLeaderboards()
		.then(lb => {			
			lb.setLeaderboardScore('planetScale', value);			
		});
	},	
	
GetLang: function (){
		var lang = ysdk.environment.i18n.lang;
		var bufferSize = lengthBytesUTF8(lang) + 1;
		var buffer = _malloc(bufferSize);
		stringToUTF8(lang, buffer, bufferSize);
		return buffer;
	},
});
