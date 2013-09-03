/// <reference path="../_references.js" />
var data = persisters.get("http://indiumapp.apphb.com/api/");

function PostsController($scope) {
    var currUser = localStorage.getItem("displayName");
    $scope.currUser = "nema";

    console.log(currUser);
    if (currUser == "bash admin") {
        $scope.currUser = currUser;
    }
    else {
        window.location = "index.html";
    }

    data.posts.all().then(function (posts) {
        $scope.posts = posts;
    }).finally(function () { 
        $scope.$apply();
    });

    $scope.RemovePost = function (postId) {
        $("#post-" + postId).remove();
        data.posts.deletePost(postId);
    }
}

function SinglePostController($scope, $routeParams) {
    $scope.tempContent = "";
    var editor = "";

    data.posts.single($routeParams.id).then(function (currPost) {
        $scope.currPost = currPost;
        $scope.currPost.id = $routeParams.id;
        
        $("#editor").ready(function () {
            $scope.tempContent = $scope.currPost.text;
            
            $("#editor").kendoEditor();

            editor = $("#editor").data("kendoEditor");
            editor.value($scope.tempContent);
        });

    }).finally(function () {
        $scope.$apply();
    });

    $scope.updatePost = function () {
        console.log(editor.value());
        var updatedPost = {
            title: $scope.currPost.title,
            text: editor.value(),
            id: $scope.currPost.id
        }
        
        data.posts.update(updatedPost).then(function () {
            console.log('success');
        }, function (err) {
            console.log(err);
        });
    }
}

function AddPostController($scope) {
    var editor = "";

    $("#editor").ready(function () {
        $("#editor").kendoEditor();

        editor = $("#editor").data("kendoEditor");
    });

    $scope.addPost = function () {
        $scope.currPost.text = editor.value();

        data.posts.add($scope.currPost).then(function () {
            alert("Post added");
        }, function (err) {
            if (!data.users.isUserLoggedIn()) {
                alert("You need to be logged in as administrator to add a new post");
            }
            else {
                alert("Post was not added");
            }

            console.log(err);
        });
    }
}