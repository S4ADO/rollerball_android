<?php
include_once 'dbconnect.php';
include_once 'functions.php';

$secretKey = "1Lnt2ZSTS6Mdc3vrysav";
$email = $_REQUEST['email'];
$emailHash = $_REQUEST['verif'];
$effect = $_REQUEST['effect'];

if(md5($email . $secretKey) == $emailHash)
{

	if($effect == "doubleJump")
	{
		$rowToUpdate = "doubleJump";
	}
	elseif($effect == "barracade")
	{
		$rowToUpdate = "Barracades";
	}
	elseif($effect == "magnet")
	{
		$rowToUpdate = "Magnet";
	}
	elseif($effect == "invincibility")
	{
		$rowToUpdate = "Invincibility";
	}
	elseif($effect == "increasedCoinValue")
	{
		$rowToUpdate = "PointsIncrease";
	}

	if ($stmt = $mysqli->prepare("UPDATE uses SET `$rowToUpdate` = `$rowToUpdate` -1 WHERE email = ?")) 
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
	echo "effect was not removed, call a plumber";
}               