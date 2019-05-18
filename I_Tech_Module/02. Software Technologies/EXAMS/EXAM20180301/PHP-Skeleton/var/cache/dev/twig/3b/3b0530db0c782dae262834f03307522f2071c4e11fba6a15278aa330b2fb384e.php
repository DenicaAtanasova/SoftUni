<?php

/* @WebProfiler/Collector/exception.html.twig */
class __TwigTemplate_f32ad73c9bc804e7d7685ce925e27ce9c7daa98efc0b9a8c89227d7076a75563 extends Twig_Template
{
    public function __construct(Twig_Environment $env)
    {
        parent::__construct($env);

        // line 1
        $this->parent = $this->loadTemplate("@WebProfiler/Profiler/layout.html.twig", "@WebProfiler/Collector/exception.html.twig", 1);
        $this->blocks = array(
            'head' => array($this, 'block_head'),
            'menu' => array($this, 'block_menu'),
            'panel' => array($this, 'block_panel'),
        );
    }

    protected function doGetParent(array $context)
    {
        return "@WebProfiler/Profiler/layout.html.twig";
    }

    protected function doDisplay(array $context, array $blocks = array())
    {
        $__internal_21af87ed552eedeb271e6eba2f7cf7452df191d3d860e8f0e68b19b32b418311 = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_21af87ed552eedeb271e6eba2f7cf7452df191d3d860e8f0e68b19b32b418311->enter($__internal_21af87ed552eedeb271e6eba2f7cf7452df191d3d860e8f0e68b19b32b418311_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", "@WebProfiler/Collector/exception.html.twig"));

        $__internal_f1a50ba766f5eefea846ac0b435c052fdd16c92fd85b4baacd56c2ae5e0e27c2 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_f1a50ba766f5eefea846ac0b435c052fdd16c92fd85b4baacd56c2ae5e0e27c2->enter($__internal_f1a50ba766f5eefea846ac0b435c052fdd16c92fd85b4baacd56c2ae5e0e27c2_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", "@WebProfiler/Collector/exception.html.twig"));

        $this->parent->display($context, array_merge($this->blocks, $blocks));
        
        $__internal_21af87ed552eedeb271e6eba2f7cf7452df191d3d860e8f0e68b19b32b418311->leave($__internal_21af87ed552eedeb271e6eba2f7cf7452df191d3d860e8f0e68b19b32b418311_prof);

        
        $__internal_f1a50ba766f5eefea846ac0b435c052fdd16c92fd85b4baacd56c2ae5e0e27c2->leave($__internal_f1a50ba766f5eefea846ac0b435c052fdd16c92fd85b4baacd56c2ae5e0e27c2_prof);

    }

    // line 3
    public function block_head($context, array $blocks = array())
    {
        $__internal_6bb2ba1c6ecb687a5cbca6e6c053b87cba224ac4c46a102fa5a6feaa70312fb3 = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_6bb2ba1c6ecb687a5cbca6e6c053b87cba224ac4c46a102fa5a6feaa70312fb3->enter($__internal_6bb2ba1c6ecb687a5cbca6e6c053b87cba224ac4c46a102fa5a6feaa70312fb3_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "head"));

        $__internal_3acdd7791bfa29230d9820bee45585a4ed72f9703a53748bc2a2ec314d8bfc2f = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_3acdd7791bfa29230d9820bee45585a4ed72f9703a53748bc2a2ec314d8bfc2f->enter($__internal_3acdd7791bfa29230d9820bee45585a4ed72f9703a53748bc2a2ec314d8bfc2f_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "head"));

        // line 4
        echo "    ";
        if ($this->getAttribute(($context["collector"] ?? $this->getContext($context, "collector")), "hasexception", array())) {
            // line 5
            echo "        <style>
            ";
            // line 6
            echo $this->env->getRuntime('Symfony\Bridge\Twig\Extension\HttpKernelRuntime')->renderFragment($this->env->getExtension('Symfony\Bridge\Twig\Extension\RoutingExtension')->getPath("_profiler_exception_css", array("token" => ($context["token"] ?? $this->getContext($context, "token")))));
            echo "
        </style>
    ";
        }
        // line 9
        echo "    ";
        $this->displayParentBlock("head", $context, $blocks);
        echo "
";
        
        $__internal_3acdd7791bfa29230d9820bee45585a4ed72f9703a53748bc2a2ec314d8bfc2f->leave($__internal_3acdd7791bfa29230d9820bee45585a4ed72f9703a53748bc2a2ec314d8bfc2f_prof);

        
        $__internal_6bb2ba1c6ecb687a5cbca6e6c053b87cba224ac4c46a102fa5a6feaa70312fb3->leave($__internal_6bb2ba1c6ecb687a5cbca6e6c053b87cba224ac4c46a102fa5a6feaa70312fb3_prof);

    }

    // line 12
    public function block_menu($context, array $blocks = array())
    {
        $__internal_13c42ddbb39dd70883823519f345cc000d49f939f5e7f34d307e6bac6ac0d46f = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_13c42ddbb39dd70883823519f345cc000d49f939f5e7f34d307e6bac6ac0d46f->enter($__internal_13c42ddbb39dd70883823519f345cc000d49f939f5e7f34d307e6bac6ac0d46f_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "menu"));

        $__internal_eeeee193eea0e31dc1a6bfb00d9096947b118eafdf902ef9b078c0697f9db1be = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_eeeee193eea0e31dc1a6bfb00d9096947b118eafdf902ef9b078c0697f9db1be->enter($__internal_eeeee193eea0e31dc1a6bfb00d9096947b118eafdf902ef9b078c0697f9db1be_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "menu"));

        // line 13
        echo "    <span class=\"label ";
        echo (($this->getAttribute(($context["collector"] ?? $this->getContext($context, "collector")), "hasexception", array())) ? ("label-status-error") : ("disabled"));
        echo "\">
        <span class=\"icon\">";
        // line 14
        echo twig_include($this->env, $context, "@WebProfiler/Icon/exception.svg");
        echo "</span>
        <strong>Exception</strong>
        ";
        // line 16
        if ($this->getAttribute(($context["collector"] ?? $this->getContext($context, "collector")), "hasexception", array())) {
            // line 17
            echo "            <span class=\"count\">
                <span>1</span>
            </span>
        ";
        }
        // line 21
        echo "    </span>
";
        
        $__internal_eeeee193eea0e31dc1a6bfb00d9096947b118eafdf902ef9b078c0697f9db1be->leave($__internal_eeeee193eea0e31dc1a6bfb00d9096947b118eafdf902ef9b078c0697f9db1be_prof);

        
        $__internal_13c42ddbb39dd70883823519f345cc000d49f939f5e7f34d307e6bac6ac0d46f->leave($__internal_13c42ddbb39dd70883823519f345cc000d49f939f5e7f34d307e6bac6ac0d46f_prof);

    }

    // line 24
    public function block_panel($context, array $blocks = array())
    {
        $__internal_40c4aebd6e7a8c1de66feebdf03e1f10d5831d0a0544c7f100efe72ee8763644 = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_40c4aebd6e7a8c1de66feebdf03e1f10d5831d0a0544c7f100efe72ee8763644->enter($__internal_40c4aebd6e7a8c1de66feebdf03e1f10d5831d0a0544c7f100efe72ee8763644_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "panel"));

        $__internal_ceee35a18f47b4e159154959767f5b4474170e1336bef727ebdbc52bcae996d7 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_ceee35a18f47b4e159154959767f5b4474170e1336bef727ebdbc52bcae996d7->enter($__internal_ceee35a18f47b4e159154959767f5b4474170e1336bef727ebdbc52bcae996d7_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "panel"));

        // line 25
        echo "    <h2>Exceptions</h2>

    ";
        // line 27
        if ( !$this->getAttribute(($context["collector"] ?? $this->getContext($context, "collector")), "hasexception", array())) {
            // line 28
            echo "        <div class=\"empty\">
            <p>No exception was thrown and caught during the request.</p>
        </div>
    ";
        } else {
            // line 32
            echo "        <div class=\"sf-reset\">
            ";
            // line 33
            echo $this->env->getRuntime('Symfony\Bridge\Twig\Extension\HttpKernelRuntime')->renderFragment($this->env->getExtension('Symfony\Bridge\Twig\Extension\RoutingExtension')->getPath("_profiler_exception", array("token" => ($context["token"] ?? $this->getContext($context, "token")))));
            echo "
        </div>
    ";
        }
        
        $__internal_ceee35a18f47b4e159154959767f5b4474170e1336bef727ebdbc52bcae996d7->leave($__internal_ceee35a18f47b4e159154959767f5b4474170e1336bef727ebdbc52bcae996d7_prof);

        
        $__internal_40c4aebd6e7a8c1de66feebdf03e1f10d5831d0a0544c7f100efe72ee8763644->leave($__internal_40c4aebd6e7a8c1de66feebdf03e1f10d5831d0a0544c7f100efe72ee8763644_prof);

    }

    public function getTemplateName()
    {
        return "@WebProfiler/Collector/exception.html.twig";
    }

    public function isTraitable()
    {
        return false;
    }

    public function getDebugInfo()
    {
        return array (  138 => 33,  135 => 32,  129 => 28,  127 => 27,  123 => 25,  114 => 24,  103 => 21,  97 => 17,  95 => 16,  90 => 14,  85 => 13,  76 => 12,  63 => 9,  57 => 6,  54 => 5,  51 => 4,  42 => 3,  11 => 1,);
    }

    /** @deprecated since 1.27 (to be removed in 2.0). Use getSourceContext() instead */
    public function getSource()
    {
        @trigger_error('The '.__METHOD__.' method is deprecated since version 1.27 and will be removed in 2.0. Use getSourceContext() instead.', E_USER_DEPRECATED);

        return $this->getSourceContext()->getCode();
    }

    public function getSourceContext()
    {
        return new Twig_Source("{% extends '@WebProfiler/Profiler/layout.html.twig' %}

{% block head %}
    {% if collector.hasexception %}
        <style>
            {{ render(path('_profiler_exception_css', { token: token })) }}
        </style>
    {% endif %}
    {{ parent() }}
{% endblock %}

{% block menu %}
    <span class=\"label {{ collector.hasexception ? 'label-status-error' : 'disabled' }}\">
        <span class=\"icon\">{{ include('@WebProfiler/Icon/exception.svg') }}</span>
        <strong>Exception</strong>
        {% if collector.hasexception %}
            <span class=\"count\">
                <span>1</span>
            </span>
        {% endif %}
    </span>
{% endblock %}

{% block panel %}
    <h2>Exceptions</h2>

    {% if not collector.hasexception %}
        <div class=\"empty\">
            <p>No exception was thrown and caught during the request.</p>
        </div>
    {% else %}
        <div class=\"sf-reset\">
            {{ render(path('_profiler_exception', { token: token })) }}
        </div>
    {% endif %}
{% endblock %}
", "@WebProfiler/Collector/exception.html.twig", "H:\\EXAM\\PHP-Skeleton\\vendor\\symfony\\symfony\\src\\Symfony\\Bundle\\WebProfilerBundle\\Resources\\views\\Collector\\exception.html.twig");
    }
}
