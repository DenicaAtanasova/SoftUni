<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
    <form>
        N: <input type="text" name="num" />
        <input type="submit" />
    </form>
    <?php
        if(isset($_GET['num'])){
            $n = intval($_GET['num']);
            $m = 1;
            for($i = 1; $i <= $n; $i ++) {
               $m *= $i;
            }
            echo $m;
        }
    ?>
</body>
</html>