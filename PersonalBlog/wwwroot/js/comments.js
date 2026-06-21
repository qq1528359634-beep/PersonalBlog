

// load comments
async function LoadComments(slug) {
    const res = await fetch(`/api/comments?slug=${slug}`);
    const comments = await res.json();

    const list = document.getElementById('comment-list');
    if (comments.length == 0) {
        list.innerHTML = '<p>There is not comments</p>';
        return;
    }
    list.innerHTML = comments.map(c => `
       <div class="comments">
            <strong>${c.authorName}</strong>
            <time>${c.CreateAt}</time>
            <p>${c.content}</p>
        </div >`
    ).join('');
}

//submit comments
