angular.module("admin", [])
	.config(["$routeProvider", function ($routeProvider) {
	    $routeProvider
			.when("/home", { templateUrl: "partials/all-posts-admin-view.html", controller: PostsController })
			.when("/posts/:id/edit", { templateUrl: "partials/single-post-edit.html", controller: SinglePostController })
			.when("/add-post", { templateUrl: "partials/add-post.html", controller: AddPostController })
			.otherwise({ redirectTo: "/home" });
	}]);
