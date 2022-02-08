function solution() {
    class Post {
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        toString() {
            return `Post: ${this.title}\nContent: ${this.content}`;
        }
    }

    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes) {
            super(title, content);

            this.likes = likes;
            this.dislikes = dislikes;
            this.comments = [];
        }

        addComment(comment) {
            this.comments.push(comment);
        }

        toString() {
            let result = super.toString() + `\nRating: ${this.likes - this.dislikes}`;

            if(this.comments.length > 0) {
                let comments = '\n';
                this.comments.forEach(c => comments += ` * ${c}\n`);

                result += comments;
            }

            return result.trim();
        }
    }

    class BlogPost extends Post {
        constructor(title, content, views) {
            super(title, content);

            this.views = views;
        }

        toString() {
            return super.toString() + `\nViews: ${this.views}`;
        }

        view() {
            this.views++;
            return this; // Връщаме така, ако искаме да можем да правим blog.view().view(); this ни е инстанцията на класа, който пък клас от своя страна е обект. В този обект имаме текущото състояние на views, както и метода view(). Или за този случай просто връщаме this.
            // return this.view.bind(this); //Връщаме така ако искаме blog.view()();
        }
    }

    return { Post, SocialMediaPost, BlogPost };
}

const classes = solution();
let post = new classes.Post("Post", "Content");

console.log(post.toString());

// Post: Post
// Content: Content

let scm = new classes.SocialMediaPost("TestTitle", "TestContent", 25, 30);

scm.addComment("Good post");
scm.addComment("Very good post");
scm.addComment("Wow!");

console.log(scm.toString());

let blog = new classes.BlogPost("TestTitle", "TestContent", 25);
console.log(blog.views);
blog.view().view();
// blog.view()();
console.log(blog.views);
console.log(blog.toString());