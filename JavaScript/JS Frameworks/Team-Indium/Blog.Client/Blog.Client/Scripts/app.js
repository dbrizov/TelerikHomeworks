/// <reference path="_references.js" />

(function () {
    /* Layouts */
    var userLayout = new kendo.Layout('<div id="user-form"></div>');
    var tagCloudLayout = new kendo.Layout('<div id="tag-cloud" class="tags"></div>');

    /* Routing */
    var data = persisters.get("http://indiumapp.apphb.com/api/");
    viewModelsFactory.setPersister(data);

    var router = new kendo.Router();

    // Home router
    router.route("/home", function () {
        
        viewsFactory.getHomeView()
            .then(function(homeViewHtml){
                $("#posts").html(homeViewHtml);
            });

        viewsFactory.getTagCloudView()
            .then(function (tagCloudViewHtml) {
                viewModelsFactory.getTagsViewModel()
                    .then(function (tagsViewModel) {
                        var view = new kendo.View(tagCloudViewHtml, { model: tagsViewModel });
                        tagCloudLayout.showIn("#tag-cloud", view);
                    })
                    .done();
            })
            .done();

        if (data.users.isUserLoggedIn()) {

            if (data.users.displayName() == "bash admin") {
                $("#admin-link").show();
            } else {
                $("#admin-link").hide();
            }

            viewsFactory.getLogoutView()
                .then(function (logoutViewHtml) {
                    viewModelsFactory.getLogoutViewModel(function () {
                        $("#admin-link").hide();
                        $("#user-form").html("");
                    })
                    .then(function (logoutViewModel) {
                        logoutViewModel.set("displayName", data.users.displayName());
                        var view = new kendo.View(logoutViewHtml, { model: logoutViewModel });

                        userLayout.showIn("#user-form", view);
                    })
                    .done();
                });
        }
    });

    // Login router
    router.route("/login", function () {
        viewsFactory.getLoginView()
            .then(function (loginViewHtml) {
                viewModelsFactory.getLoginRegisterViewModel(function () {
                    router.navigate("/home");
                })
                .then(function (loginViewModel) {
                    var view = new kendo.View(loginViewHtml, { model: loginViewModel });

                    userLayout.showIn("#user-form", view);
                })
                .done();
            });
    });

    // Register router
    router.route("/register", function () {
        viewsFactory.getRegisterView()
            .then(function (registerViewHtml) {
                viewModelsFactory.getLoginRegisterViewModel(function () {
                    router.navigate("/home");
                })
                .then(function (registerViewModel) {
                    var view = new kendo.View(registerViewHtml, { model: registerViewModel });

                    userLayout.showIn("#user-form", view);
                })
                .done();
            });
    });

    // All Posts router
    router.route("/posts", function () {
        viewsFactory.getAllPostsView()
            .then(function (postsViewHtml) {
                var template = kendo.template(postsViewHtml);
                data.posts.all()
                    .then(function (posts) {
                        $("#posts").html(template(posts));
                    });
            });
    });

    // Single Post router
    router.route("/posts/:id", function (id) {
        viewsFactory.getSinglePostView()
            .then(function (postViewHtml) {
                var template = kendo.template(postViewHtml);
                data.posts.single(id)
                    .then(function (post) {
                        $("#posts").html(template(post));
                    });
            });
    });

    // All Tags router
    //router.route("/tags", function () {
    //});

    // Posts by tag router
    router.route("/tags/:id/posts", function (id) {
        viewsFactory.getAllPostsView()
        .then(function (postsViewHtml) {
            var template = kendo.template(postsViewHtml);
            data.tags.postsByTag(id)
            .then(function (posts) {
                $("#posts").html(template(posts));
            });
        });
    });

    // Comment on a post
    router.route("/posts/:id/comment", function (id) {
        var commentText = $("#comment textarea").val();
        data.posts.comment(commentText, id)
            .then(function () {
                router.navigate("/posts/" + id);
            }, function () {
                alert("You need to be logged in to leave a comment");
            });
    });

    // Go to admin panel
    router.route("/admin", function (id) {
        window.location = "admin.html";
    });

    $(document).ready(function () {
        router.start();
        userLayout.render("#user-content");
        tagCloudLayout.render("#main-content aside.col-md-3");

        router.navigate("/home");
    });
})();