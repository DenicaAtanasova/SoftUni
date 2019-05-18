<?php

/* @WebProfiler/Collector/router.html.twig */
class __TwigTemplate_09886c37796d81d574b2448cf2a22ea32da8dad546b69f22c376ce19a869ce97 extends Twig_Template
{
    public function __construct(Twig_Environment $env)
    {
        parent::__construct($env);

        // line 1
        $this->parent = $this->loadTemplate("@WebProfiler/Profiler/layout.html.twig", "@WebProfiler/Collector/router.html.twig", 1);
        $this->blocks = array(
            'toolbar' => array($this, 'block_toolbar'),
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
        $__internal_aaec3b796d57f6063b30194defd36fbb822c19681d927f84264c5320f0c2196f = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_aaec3b796d57f6063b30194defd36fbb822c19681d927f84264c5320f0c2196f->enter($__internal_aaec3b796d57f6063b30194defd36fbb822c19681d927f84264c5320f0c2196f_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", "@WebProfiler/Collector/router.html.twig"));

        $__internal_f3ca3b3271decff20279406b97cf9f3bbaf10f3e84cd35afaca1e21ab0d216f6 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_f3ca3b3271decff20279406b97cf9f3bbaf10f3e84cd35afaca1e21ab0d216f6->enter($__internal_f3ca3b3271decff20279406b97cf9f3bbaf10f3e84cd35afaca1e21ab0d216f6_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", "@WebProfiler/Collector/router.html.twig"));

        $this->parent->display($context, array_merge($this->blocks, $blocks));
        
        $__internal_aaec3b796d57f6063b30194defd36fbb822c19681d927f84264c5320f0c2196f->leave($__internal_aaec3b796d57f6063b30194defd36fbb822c19681d927f84264c5320f0c2196f_prof);

        
        $__internal_f3ca3b3271decff20279406b97cf9f3bbaf10f3e84cd35afaca1e21ab0d216f6->leave($__internal_f3ca3b3271decff20279406b97cf9f3bbaf10f3e84cd35afaca1e21ab0d216f6_prof);

    }

    // line 3
    public function block_toolbar($context, array $blocks = array())
    {
        $__internal_6821c38b65f5413d6e92625c17492d7422d8821c263658a71c0a4e9da8734c9d = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_6821c38b65f5413d6e92625c17492d7422d8821c263658a71c0a4e9da8734c9d->enter($__internal_6821c38b65f5413d6e92625c17492d7422d8821c263658a71c0a4e9da8734c9d_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "toolbar"));

        $__internal_3080d81a621b9b9c4ed558e3d2168166397bfdb3258f17491a53ae847891c35f = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_3080d81a621b9b9c4ed558e3d2168166397bfdb3258f17491a53ae847891c35f->enter($__internal_3080d81a621b9b9c4ed558e3d2168166397bfdb3258f17491a53ae847891c35f_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "toolbar"));

        
        $__internal_3080d81a621b9b9c4ed558e3d2168166397bfdb3258f17491a53ae847891c35f->leave($__internal_3080d81a621b9b9c4ed558e3d2168166397bfdb3258f17491a53ae847891c35f_prof);

        
        $__internal_6821c38b65f5413d6e92625c17492d7422d8821c263658a71c0a4e9da8734c9d->leave($__internal_6821c38b65f5413d6e92625c17492d7422d8821c263658a71c0a4e9da8734c9d_prof);

    }

    // line 5
    public function block_menu($context, array $blocks = array())
    {
        $__internal_9c71a0a381e1c86120a12cb65609ec305d7d2deb2dd8efa45e2555d9f17885e4 = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_9c71a0a381e1c86120a12cb65609ec305d7d2deb2dd8efa45e2555d9f17885e4->enter($__internal_9c71a0a381e1c86120a12cb65609ec305d7d2deb2dd8efa45e2555d9f17885e4_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "menu"));

        $__internal_7846032b6eb695df25ee07858565fc2d1ae05da8df9cffc60ec68c523dc21419 = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_7846032b6eb695df25ee07858565fc2d1ae05da8df9cffc60ec68c523dc21419->enter($__internal_7846032b6eb695df25ee07858565fc2d1ae05da8df9cffc60ec68c523dc21419_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "menu"));

        // line 6
        echo "<span class=\"label\">
    <span class=\"icon\">";
        // line 7
        echo twig_include($this->env, $context, "@WebProfiler/Icon/router.svg");
        echo "</span>
    <strong>Routing</strong>
</span>
";
        
        $__internal_7846032b6eb695df25ee07858565fc2d1ae05da8df9cffc60ec68c523dc21419->leave($__internal_7846032b6eb695df25ee07858565fc2d1ae05da8df9cffc60ec68c523dc21419_prof);

        
        $__internal_9c71a0a381e1c86120a12cb65609ec305d7d2deb2dd8efa45e2555d9f17885e4->leave($__internal_9c71a0a381e1c86120a12cb65609ec305d7d2deb2dd8efa45e2555d9f17885e4_prof);

    }

    // line 12
    public function block_panel($context, array $blocks = array())
    {
        $__internal_f654aae1c46a34e5a27015f4ef13e088f03b691d4a58d46c72a0d1e2b6ac229b = $this->env->getExtension("Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension");
        $__internal_f654aae1c46a34e5a27015f4ef13e088f03b691d4a58d46c72a0d1e2b6ac229b->enter($__internal_f654aae1c46a34e5a27015f4ef13e088f03b691d4a58d46c72a0d1e2b6ac229b_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "panel"));

        $__internal_b2469601a171ee6cb9f6c6f6ab2808c3b26a90d323f2a3829e9de1d40eb2f20e = $this->env->getExtension("Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension");
        $__internal_b2469601a171ee6cb9f6c6f6ab2808c3b26a90d323f2a3829e9de1d40eb2f20e->enter($__internal_b2469601a171ee6cb9f6c6f6ab2808c3b26a90d323f2a3829e9de1d40eb2f20e_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "panel"));

        // line 13
        echo "    ";
        echo $this->env->getRuntime('Symfony\Bridge\Twig\Extension\HttpKernelRuntime')->renderFragment($this->env->getExtension('Symfony\Bridge\Twig\Extension\RoutingExtension')->getPath("_profiler_router", array("token" => ($context["token"] ?? $this->getContext($context, "token")))));
        echo "
";
        
        $__internal_b2469601a171ee6cb9f6c6f6ab2808c3b26a90d323f2a3829e9de1d40eb2f20e->leave($__internal_b2469601a171ee6cb9f6c6f6ab2808c3b26a90d323f2a3829e9de1d40eb2f20e_prof);

        
        $__internal_f654aae1c46a34e5a27015f4ef13e088f03b691d4a58d46c72a0d1e2b6ac229b->leave($__internal_f654aae1c46a34e5a27015f4ef13e088f03b691d4a58d46c72a0d1e2b6ac229b_prof);

    }

    public function getTemplateName()
    {
        return "@WebProfiler/Collector/router.html.twig";
    }

    public function isTraitable()
    {
        return false;
    }

    public function getDebugInfo()
    {
        return array (  94 => 13,  85 => 12,  71 => 7,  68 => 6,  59 => 5,  42 => 3,  11 => 1,);
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

{% block toolbar %}{% endblock %}

{% block menu %}
<span class=\"label\">
    <span class=\"icon\">{{ include('@WebProfiler/Icon/router.svg') }}</span>
    <strong>Routing</strong>
</span>
{% endblock %}

{% block panel %}
    {{ render(path('_profiler_router', { token: token })) }}
{% endblock %}
", "@WebProfiler/Collector/router.html.twig", "H:\\EXAM\\PHP-Skeleton\\vendor\\symfony\\symfony\\src\\Symfony\\Bundle\\WebProfilerBundle\\Resources\\views\\Collector\\router.html.twig");
    }
}
