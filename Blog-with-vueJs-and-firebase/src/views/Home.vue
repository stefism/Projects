<template>
  <div class="home">
    <BlogPost :post="welcomeScreen" />
    <BlogPost :post="post" v-for="(post, index) in sampleBlogPost" :key="index" />
  </div>
</template>

<script>
import BlogPost from '../components/BlogPost-comp.vue';

export default {
  name: "Home",
  components: {
    BlogPost
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
    }
  }
};
</script>
