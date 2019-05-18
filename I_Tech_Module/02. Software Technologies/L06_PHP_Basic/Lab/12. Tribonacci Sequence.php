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
    if (isset($_GET['num'])) {
        $n = intval($_GET['num']);
        $addNum1 = 1;
        $addNum2 = 1;
        $fibNum = 2;
        echo  1 . ' ';
        echo  1 . ' ';
        echo  2 . ' ';

        for ($i = 1; $i < $n - 2; $i ++) {
            $sum = $addNum1 + $addNum2 + $fibNum;
            $addNum1 = $addNum2;
            $addNum2 = $fibNum;
            $fibNum = $sum;
            echo $fibNum . ' ';
        }
    }
    ?>
</body>
</html>