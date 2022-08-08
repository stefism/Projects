<template>
  <div class="blog-card">
    <div v-show="editPost" class="icons">
      <div @click="editCurrentPost" class="icon">
        <font-awesome-icon class="edit" icon="fa-solid fa-pen-to-square" />
      </div>
      <div @click="deletePost" class="icon">
        <font-awesome-icon class="delete" icon="fa-solid fa-trash-can" />
      </div>
    </div>
    <img :src="post.blogCoverPhoto" alt="image" />
    <div class="info">
      <h4>{{ post.blogTitle }}</h4>
      <h6>Пуснат на {{ new Date(post.blogDate).toLocaleString('bg-bg') }}</h6>
      <router-link class="link" :to="{ name: 'ViewBlog', params: { blogid: this.post.blogId } }"
        >Вижте поста <font-awesome-icon class="arrow" icon="fa-solid fa-right-long" /></router-link>
    </div>
  </div>
</template>

<script>
import { library } from '@fortawesome/fontawesome-svg-core';
import { faPenToSquare, faTrashCan, faRightLong } from '@fortawesome/free-solid-svg-icons';
library.add([faPenToSquare, faTrashCan, faRightLong]);

export default {
  name: "blogCard",
  props: ["post"],
  methods: {
    deletePost() {
      this.$store.dispatch('deletePost', this.post.blogId);
    },
    editCurrentPost() {
      this.$router.push({ name: 'EditBlog', params: { blogid: this.post.blogId } });
    }
  },
  computed: {
    editPost() {
        return this.$store.state.editPost;
    }
  }
};
</script>

<style lang="scss" scoped>
.blog-card {
  position: relative;
  cursor: pointer;
  display: flex;
  flex-direction: column;
  border-radius: 8px;
  background-color: #fff;
  min-height: 420px;
  transition: 0.5s ease all;

  &:hover {
    transform: rotateZ(-1deg) scale(1.01);
    box-shadow: 0 4px 6px -1px black, 0 2px 4px -1px black;
  }

  .icons {
    display: flex;
    position: absolute;
    top: 10px;
    right: 10px;
    z-index: 99;

    .icon {
      display: flex;
      justify-content: center;
      align-items: center;
      width: 35px;
      height: 35px;
      border-radius: 50%;
      background-color: #fff;
      transition: 0.5s ease all;

      &:hover {
        background-color: #303030;

        .edit,
        .delete {
          path {
            fill: #fff;
          }
        }
      }

      &:nth-child(1) {
        margin-right: 8px;
      }

      .edit,
      .delete {
        pointer-events: none;
        height: 15px;
        width: auto;
      }
    }
  }

  img {
    display: block;
    border-radius: 8px 8px 0 0;
    z-index: 1;
    width: 100%;
    min-height: 200px;
    object-fit: cover;
  }

  .info {
    display: flex;
    flex-direction: column;
    height: 100%;
    z-index: 3;
    padding: 32px 16px;
    color: #000;

    h4 {
        padding-bottom: 8px;
        font-size: 20px;
        font-weight: 300;
    }

    h6 {
        font-weight: 400;
        font-size: 12px;
        padding-bottom: 16px;
    }

    .link {
        display:  inline-flex;
        align-items: center;
        margin-top: auto;
        font-weight: 500;
        padding-top: 20px;
        font-size: 12px;
        padding-bottom: 4px;
        transition: 0.5s ease-in all;

        &:hover {
            color: rgba(48, 48, 48, 0.8);
        }

        .arrow {
            width: 10px;
        }
    }
  }
}
</style>
