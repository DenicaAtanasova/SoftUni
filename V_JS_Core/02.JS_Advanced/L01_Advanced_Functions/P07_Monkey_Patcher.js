function solution(command) {

    let totalVotes = this.upvotes + this.downvotes;
    let balance = this.upvotes - this.downvotes;

    function getRating(upvotes, downvotes){

        if (totalVotes < 10) {
            return 'new';
        } else if (upvotes > (upvotes + downvotes) * 0.66) {
            return 'hot';
        } else if (balance >= 0 && (upvotes > 100 || downvotes > 100)) {
            return 'controversial';
        } else if (balance < 0) {
            return 'unpopular';
        } else {
            return 'new';
        }
    }

    function getVotes(upvotes, downvotes){
        if(upvotes + downvotes > 50){
            let votingRaise = Math.ceil(Math.max(upvotes, downvotes) * 0.25);
            let reportUpvotes = upvotes + votingRaise;
            let reportDownvotes = downvotes + votingRaise;
            return [reportUpvotes, reportDownvotes];
        } else {
            return [upvotes, downvotes];
        }
    };
   

    const upvote = () => this.upvotes++;

    const downvote = () => this.downvotes++;

    const score = () => {

        let balance = this.upvotes - this.downvotes;
        let rating = getRating(this.upvotes, this.downvotes);
        let reportVotes = getVotes(this.upvotes, this.downvotes);

        return [reportVotes[0], reportVotes[1], balance, rating];
    }

    let commands = {
        upvote,
        downvote,
        score
    }

    return commands[command]()
}

var forumPost = {
    id: '1234',
    author: 'author name',
    content: 'these fields are irrelevant',
    upvotes: 4,
    downvotes: 5
};

console.log(solution.call(forumPost, 'score'))