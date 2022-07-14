<template>
  <div class="home">
    <BlogPost v-if="!user" :post="welcomeScreen" />
    <BlogPost :post="post" v-for="(post, index) in sampleBlogPost" :key="index" />
    <div class="blog-card-wrap">
      <div class="container">
        <h3>Вижте повече скорошни постове</h3>
        <div class="blog-cards">
          <BlogCard :post="card" v-for="(card, index) in sampleBlogCards" :key="index"/>
        </div>
      </div>
    </div>
    <div v-if="!user" class="updates">
        <div class="container">
          <h2>Никога не пропускайте пост. Регистрирайте се безплатно.</h2>
          <router-link class="router-button" to="#">
            Регистрация за блоговете <Arrow class="arrow arrow-light" />
          </router-link>
        </div>
    </div>
  </div>
</template>

<script>
import BlogPost from '../components/BlogPost-comp.vue';
import BlogCard from '../components/BlogCard-comp.vue';
import Arrow from "../assets/Icons/arrow-right-light.svg";

export default {
  name: "Home",
  components: {
    BlogPost, BlogCard, Arrow
  },
  data() {
    return {
      welcomeScreen: {
        title: 'Добре дошли',
        blogPost: 'Седмични блог артикули за всички неща от програмирането, включително HTML, CSS, JavaScript и други.',
        welcomeScreen: true,
        photo: 'coding'
      },
      sampleBlogPost: [
        {
          title: 'Това е филтърно заглавие',
          blogHTML: 'Това е филтър блог пост заглавие',
          blogCoverPhoto: 'beautiful-stories',
        },
        {
          title: 'Две Това е филтърно заглавие 2 ',
          blogHTML: 'Две Това е филтър блог пост заглавие 2',
          blogCoverPhoto: 'designed-for-everyone',
        }
      ]
    };
  },computed: {
    sampleBlogCards() {
      return this.$store.state.sampleBlogCards;
    },
    user() {
      return this.$store.state.user;
    }
  }
};
</script>

<style lang="scss" scoped>
.blog-card-wrap {
  h3 {
    font-weight: 300;
    font-size: 28px;
    margin-bottom: 3px;
  }
}

.updates {
  .container {
    padding: 100px 25px;
    display: flex;
    flex-direction: column;
    align-items: center;
    @media (min-width: 800px) {
      padding: 125px 25px;
      flex-direction: row;
    }

    .router-button {
      display: flex;
      font-size: 14px;
      text-decoration: none;
      @media (min-width: 800px) {
        margin-left: auto;
      }
    }

    h2 {
      font-weight: 300;
      font-size: 32px;
      max-width: 425px;
      width: 100%;
      text-align: center;
      text-transform: uppercase;
      @media (min-width: 800px) {
        text-align: initial;
        font-size: 40px;
      }
    }
  }
}
</style>
