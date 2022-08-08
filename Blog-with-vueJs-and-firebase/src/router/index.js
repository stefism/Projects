import Vue from "vue";
import VueRouter from "vue-router";

import Home from "../views/Home.vue";
import Blogs from "../views/Blogs-view.vue";
import Login from "../views/Login-view.vue";
import Register from "../views/Register-view.vue";
import ForgotPassword from "../views/ForgotPassword-view.vue";
import Admin from "../views/Admin-view.vue";
import Profile from "../views/Profile-view.vue";
import CreatePost from '../views/CreatePost-view.vue';
import BlogPreview from '../views/BlogPreview-view.vue';
import ViewBlog from '../views/ViewBlog-view.vue';
import EditBlog from '../views/EditPost-view.vue';

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home,
    meta: {
      title: 'Начало'
    }
  },
  {
    path: "/blogs",
    name: "Blogs",
    component: Blogs,
    meta: {
      title: 'Блогове'
    }
  },
  {
    path: "/login",
    name: "Login",
    component: Login,
    meta: {
      title: 'Вход'
    }
  },
  {
    path: "/register",
    name: "Register",
    component: Register,
    meta: {
      title: 'Регистрация'
    }
  },
  {
    path: "/forgot-password",
    name: "ForgotPassword",
    component: ForgotPassword,
    meta: {
      title: 'Забравена парола'
    }
  },
  {
    path: "/admin",
    name: "Admin",
    component: Admin,
    meta: {
      title: 'Администрация'
    }
  },
  {
    path: "/profile",
    name: "Profile",
    component: Profile,
    meta: {
      title: 'Потребителски профил'
    }
  },
  {
    path: "/create-post",
    name: "CreatePost",
    component: CreatePost,
    meta: {
      title: 'Нов пост'
    }
  },
  {
    path: "/blog-preview",
    name: "BlogPreview",
    component: BlogPreview,
    meta: {
      title: 'Предварителен преглед'
    }
  },
  {
    path: "/view-blog/:blogid",
    name: "ViewBlog",
    component: ViewBlog,
    meta: {
      title: 'Преглед на поста'
    }
  },
  {
    path: "/edit-blog/:blogid",
    name: "EditBlog",
    component: EditBlog,
    meta: {
      title: 'Редакция на поста'
    }
  }
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

router.beforeEach((to, from, next) => {
  document.title = `${to.meta.title} | Сайт за блогове`;
  next();
});

export default router;
