<?php
include_once 'dbconnect.php';
include_once 'functions.php';

$secretKey = "1Lnt2ZSTS6Mdc3vrysav";
$email = $_REQUEST['email'];
$emailHash = $_REQUEST['verif'];
$effect = $_REQUEST['effect'];

$djCost = 50;
$invCost = 400;
$icvCost = 350;
$mgCost = 200;
$brCost = 250;

if(md5($email . $secretKey) == $emailHash)
{
	$sql = "";
	if ($stmt = $mysqli->prepare("SELECT  u.money
                FROM accounts a JOIN uses u ON u.email = a.email WHERE a.email =  ?
                LIMIT 1")) 
    {
                $stmt->bind_param('s', $email);  // Bind "$email" to parameter.
                $stmt->execute();    // Execute the prepared query.
                $stmt->store_result();
         
                // get variables from result.
                $stmt->bind_result($money);
                $stmt->fetch();
    }
    else
    {
        echo "email doesn't exist couldn't retreieve money";
    }               
	if($effect == "doubleJump")
    {
        if($money >= $djCost)
        {
             if ($stmt = $mysqli->prepare("UPDATE uses SET doubleJump = doubleJump + 1, `money` = `money` - $djCost
                        WHERE email = ?
                        LIMIT 1")) 
             {
                        $stmt->bind_param('s', $email);  // Bind "$email" to parameter.
                        $stmt->execute();    // Execute the prepared query.
                        $stmt->store_result();
             }
             echo "done";
             echo ":";
             echo "done";
        }
        else
        {
            echo "Not";
            echo ":";
            echo "Enough";
        }
    }
    elseif($effect == "invincibility")
    {
        if($money >= $invCost)
        {
             if ($stmt = $mysqli->prepare("UPDATE uses SET invincibility = invincibility + 1, `money` = `money` - $invCost
                        WHERE email = ?
                        LIMIT 1")) 
             {
                        $stmt->bind_param('s', $email);  // Bind "$email" to parameter.
                        $stmt->execute();    // Execute the prepared query.
                        $stmt->store_result();
             }
             echo "done";
             echo ":";
             echo "done";
        }
        else
        {
            echo "Not";
            echo ":";
            echo "Enough";
        }
    }
    elseif($effect == "ICV")
    {
        if($money >= $icvCost)
        {
             if ($stmt = $mysqli->prepare("UPDATE uses SET PointsIncrease  = PointsIncrease + 1, `money` = `money` - $icvCost
                        WHERE email = ?
                        LIMIT 1")) 
             {
                        $stmt->bind_param('s', $email);  // Bind "$email" to parameter.
                        $stmt->execute();    // Execute the prepared query.
                        $stmt->store_result();
             }
             echo "done";
             echo ":";
             echo "done";
        }
        else
        {
            echo "Not";
            echo ":";
            echo "Enough";
        }
    }
    elseif($effect == "barracades")
    {
        if($money >= $brCost)
        {
             if ($stmt = $mysqli->prepare("UPDATE uses SET Barracades  = Barracades + 1, `money` = `money` - $brCost
                        WHERE email = ?
                        LIMIT 1")) 
             {
                        $stmt->bind_param('s', $email);  // Bind "$email" to parameter.
                        $stmt->execute();    // Execute the prepared query.
                        $stmt->store_result();
             }
             echo "done";
             echo ":";
             echo "done";
        }
        else
        {
            echo "Not";
            echo ":";
            echo "Enough";
        }
    }
    elseif($effect == "magnet")
    {
        if($money >= $mgCost)
        {
             if ($stmt = $mysqli->prepare("UPDATE uses SET Magnet  = Magnet + 1, `money` = `money` - $mgCost
                        WHERE email = ?
                        LIMIT 1")) 
             {
                        $stmt->bind_param('s', $email);  // Bind "$email" to parameter.
                        $stmt->execute();    // Execute the prepared query.
                        $stmt->store_result();
             }
             echo "done";
             echo ":";
             echo "done";
        }
        else
        {
            echo "Not";
            echo ":";
            echo "Enough";
        }
    }
    else
    {
        echo "no such effect";
    }
}
else
{
	echo "can`t verify user details";
}

?>