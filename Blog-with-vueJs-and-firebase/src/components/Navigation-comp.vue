<template>
  <header>
    <nav class="container">
      <div class="branding">
        <router-link class="header" :to="{ name: 'Home' }"
          >Сайт за Блогове</router-link
        >
      </div>
      <div class="nav-links">
        <ul v-show="!mobile">
          <router-link class="link" :to="{ name: 'Home' }">Начало</router-link>
          <router-link class="link" :to="{ name: 'Blogs' }">Блогове</router-link>
          <router-link class="link" to="#">Напиши пост</router-link>
          <router-link class="link" to="#">Вход / Регистрация</router-link>
        </ul>
      </div>
    </nav>
    <MenuIcon @click="toggleMobileNav" v-show="mobile" class="menu-icon" />
    <Transition name="mobile-nav">
      <ul v-show="mobileNav" class="mobile-nav">
        <router-link class="link" :to="{ name: 'Home' }">Начало</router-link>
        <router-link class="link" :to="{ name: 'Blogs' }">Блогове</router-link>
        <router-link class="link" to="#">Напиши пост</router-link>
        <router-link class="link" to="#">Вход / Регистрация</router-link>
      </ul>
    </Transition>
  </header>
</template>

<script>
import MenuIcon from "../assets/Icons/bars-regular.svg";

export default {
  name: "Navigation",
  components: {
    MenuIcon,
  },

  data() {
    return {
        mobile: null,
        mobileNav: null,
        windowWidth: null
    };
  },

  created() {
    window.addEventListener('resize', this.checkScreen);
    this.checkScreen();
  },

  methods: {
    checkScreen() {
        this.windowWidth = window.innerWidth;

        if(this.windowWidth <= 750) {
            this.mobile = true; 
        } else {
            this.mobile = false;
            this.mobileNav = false;
        }
    },
    toggleMobileNav() {
        this.mobileNav = !this.mobileNav;
    }
  }
};
</script>

<style lang="scss" scoped>
header {
  background-color: #fff;
  padding: 0 25px;
  box-shadow: 0 4px 6px -1px black, 0 2px 4px -1px black;
  z-index: 99;

  .link {
    font-weight: 500;
    padding: 0 8px;
    transition: 0.3s color ease;

    &:hover {
      color: #1eb8b8;
    }
  }

  nav {
    display: flex;
    padding: 25px 0;

    .branding {
      display: flex;
      align-items: center;

      .header {
        font-weight: 600;
        font-size: 24px;
        color: black;
        text-decoration: none;
      }
    }

    .nav-links {
      position: relative;
      display: flex;
      flex: 1;
      align-items: center;
      justify-content: flex-end;

      ul {
        margin-right: 32px;

        .link {
          margin-right: 32px;
        }

        .link:last-child {
          margin-right: 0;
        }
      }
    }
  }

  .menu-icon {
    cursor: pointer;
    position: absolute;
    top: 32px;
    right: 25px;
    height: 25px;
    width: auto;
  }

  .mobile-nav {
    padding: 20px;
    width: 70%;
    max-width: 250px;
    display: flex;
    flex-direction: column;
    position: fixed;
    height: 100%;
    background-color: #303030;
    top: 0;
    left: 0;

    .link {
        padding: 15px 0;
        color: white;
    }
  }

  .mobile-nav-enter-active, .mobile-nav-leave-active {
    transition: all 1s ease;
  }

  .mobile-nav-enter {
    transform: translateX(-250px);
  }

  .mobile-nav-enter-to {
    transform: translateX(0);
  }

  .mobile-nav-leave-to {
    transform: translateX(-250px);
  }
}
</style>
