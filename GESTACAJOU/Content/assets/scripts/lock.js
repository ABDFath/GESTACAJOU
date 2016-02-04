var Lock = function () {

    return {
        //main function to initiate the module
        init: function () {

             $.backstretch([
		        "Content/assets/img/bg/1.jpg",
		        "Content/assets/img/bg/2.jpg",
		        "Content/assets/img/bg/3.jpg",
		        "Content/assets/img/bg/4.jpg"
		        ], {
		          fade: 1000,
		          duration: 8000
		      });
        }

    };

}();