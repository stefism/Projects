import Vue from "vue";
import VueRouter from "vue-router";

import firebase from "firebase/app";
import 'firebase/auth';

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
      title: 'Начало',
      requiresAuth: false
    }
  },
  {
    path: "/blogs",
    name: "Blogs",
    component: Blogs,
    meta: {
      title: 'Блогове',
      requiresAuth: false
    }
  },
  {
    path: "/login",
    name: "Login",
    component: Login,
    meta: {
      title: 'Вход',
      requiresAuth: false
    }
  },
  {
    path: "/register",
    name: "Register",
    component: Register,
    meta: {
      title: 'Регистрация',
      requiresAuth: false
    }
  },
  {
    path: "/forgot-password",
    name: "ForgotPassword",
    component: ForgotPassword,
    meta: {
      title: 'Забравена парола',
      requiresAuth: false
    }
  },
  {
    path: "/admin",
    name: "Admin",
    component: Admin,
    meta: {
      title: 'Администрация',
      requiresAuth: true
    }
  },
  {
    path: "/profile",
    name: "Profile",
    component: Profile,
    meta: {
      title: 'Потребителски профил',
      requiresAuth: true
    }
  },
  {
    path: "/create-post",
    name: "CreatePost",
    component: CreatePost,
    meta: {
      title: 'Нов пост',
      requiresAuth: true
    }
  },
  {
    path: "/blog-preview",
    name: "BlogPreview",
    component: BlogPreview,
    meta: {
      title: 'Предварителен преглед',
      requiresAuth: true
    }
  },
  {
    path: "/view-blog/:blogid",
    name: "ViewBlog",
    component: ViewBlog,
    meta: {
      title: 'Преглед на поста',
      requiresAuth: false
    }
  },
  {
    path: "/edit-blog/:blogid",
    name: "EditBlog",
    component: EditBlog,
    meta: {
      title: 'Редакция на поста',
      requiresAuth: true
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

router.beforeEach(async (to, from, next) => {
  let user = firebase.auth().currentUser;
  let admin = null;

  if(user) {
    let token = await user.getIdTokenResult();
    admin = await token.claims.email == 'stef4otm@gmail.com';
  }

  if(to.matched.some(res => res.meta.requiresAuth)) {
    if(user) {
      if(to.matched.some(res => res.meta.requiresAdmin)) {
        if(admin) {
          return next();
        }       
        return next({ name: 'Home' });
      }
      return next();
    }
    return next({ name: 'Home' });
  }
  return next();
});

export default router;
